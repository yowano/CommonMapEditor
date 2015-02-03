using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapEditor
{
  public partial class Form1 : Form
  {
    // 定数
    readonly Size chipSize = new Size( 16, 16 );
    readonly Size chipsetGridSize = new Size( 16, 16 );
    readonly Size mapGridSize = new Size( 16, 16 );

    // 定数プロパティ
    int MapSquareNum { get{ return mapGridSize.Width * mapGridSize.Height; } }

    // データ
    int[] mapData;

    // バッファ
    Image mapImageBuf;
    Image chipsetImageBuf;

    // 選択中
    int selectedMapSquareID = 0;
    int selectedChipID = 0;

    // モード
    bool isLocating = false;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Form1()
    {
      // 自動生成された初期化
      InitializeComponent();
    }

    /// <summary>
    /// フォーム初期化処理
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントデータ</param>
    private void Form1_Load( object sender, EventArgs e )
    {
      // バッファ作成
      mapImageBuf = new Bitmap( mapView.Width, mapView.Height );
      chipsetImageBuf = chipsetView.Image.Clone() as Bitmap;      // デザイナーで設定されたデフォルト画像でバッファを初期化

      // ピクチャボックスのイメージ作成
      mapView.Image = new Bitmap( mapView.Width, mapView.Height );
      selectedMapSquareView.Image = new Bitmap( selectedMapSquareView.Width, selectedMapSquareView.Height );
      selectedChipView.Image = new Bitmap( selectedChipView.Width, selectedChipView.Height );

      // データ初期化
      mapData = new int[mapGridSize.Width * mapGridSize.Height];

      // バッファ初期化
      DrawMapBuf();

      // ビュー初期化
      DrawMapView();
      DrawChipsetView();
      DrawSelectedMapSquareView();
      DrawSelectedChipView();
    }

    /// <summary>
    /// チップ設置開始処理
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントデータ</param>
    private void mapView_MouseDown( object sender, MouseEventArgs e )
    {
      // 左ボタンが押されていなければ何もしない
      if( e.Button != System.Windows.Forms.MouseButtons.Left ) return;

      // モード変更
      isLocating = true;

      // チップを設置
      LocateChip();

      // ビュー更新
      DrawMapView();
      DrawSelectedMapSquareView();
    }

    /// <summary>
    /// チップ設置終了処理
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントデータ</param>
    private void mapView_MouseUp( object sender, MouseEventArgs e )
    {
      // 左ボタンが離されたわけではないのなら何もしない
      if( e.Button != System.Windows.Forms.MouseButtons.Left ) return;

      // モード変更
      isLocating = false;
    }

    /// <summary>
    /// 現在座標取得・チップ設置処理
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントデータ</param>
    private void mapView_MouseMove( object sender, MouseEventArgs e )
    {
      // マウス座標から、マウスが置かれているマスのIDを求める
      Point mapSquarePosOnGrid = new Point( e.X / chipSize.Width, e.Y / chipSize.Height );  // マップのマスのグリッド上座標
      int mapSquareID = mapSquarePosOnGrid.X + (mapSquarePosOnGrid.Y * mapGridSize.Width);  // 現在のマスIDを更新

      // 選択中マスIDと、今求めたマスIDが異なっていた場合
      if( selectedMapSquareID != mapSquareID )
      {
        // 求めたIDを選択中マスIDに設定
        selectedMapSquareID = mapSquareID;

        // 選択中マス座標ラベル更新
        selectedMapSquareXLabel.Text = "X:" + mapSquarePosOnGrid.X.ToString();
        selectedMapSquareYLabel.Text = "Y:" + mapSquarePosOnGrid.Y.ToString();

        // チップ設置モードなら、チップを設置
        if( isLocating ) LocateChip();

        // ビューの更新
        DrawMapView();
        DrawSelectedMapSquareView();
      }
    }

    /// <summary>
    /// チップセット選択処理
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントデータ</param>
    private void chipsetView_MouseDown( object sender, MouseEventArgs e )
    {
      // 左ボタンが押されていなければ何もしない
      if( e.Button != System.Windows.Forms.MouseButtons.Left ) return;

      // マウス座標から、クリックされたチップのIDを求め、選択中チップIDに設定
      Point chipPosOnGrid = new Point( e.X / chipSize.Width, e.Y / chipSize.Height );   // チップのグリッド上座標
      selectedChipID = chipPosOnGrid.X + (chipPosOnGrid.Y * chipsetGridSize.Width);     // 選択中チップIDを更新

      // 選択中チップ座標ラベル更新
      selectedChipXLabel.Text = "X:" + chipPosOnGrid.X.ToString();
      selectedChipYLabel.Text = "Y:" + chipPosOnGrid.Y.ToString();

      // ビューを更新
      DrawChipsetView();
      DrawSelectedChipView();
    }

    /// <summary>
    /// マップデータ読込処理
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントデータ</param>
    private void mapLoadButton_Click( object sender, EventArgs e )
    {
      // ダイアログを開く
      if( openMapDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
      {
        // ファイルを開く
        using( FileStream fs = new FileStream( openMapDialog.FileName, FileMode.Open, FileAccess.Read ) )
        {
          // バイナリリーダに開いたファイルをセット
          BinaryReader br = new BinaryReader( fs );

          // マップデータを読み込む
          for( int i = 0; i < mapData.Length; i++ )
          {
            mapData[i] = br.ReadInt32();
          }

          // ビューを更新
          DrawMapView();
          DrawSelectedMapSquareView();

          MessageBox.Show( "マップデータ読み込み完了！" );
        }
      }
    }

    /// <summary>
    /// マップデータ記録処理
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントデータ</param>
    private void mapSaveButton_Click( object sender, EventArgs e )
    {
      // ダイアログを開く
      if( saveMapDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
      {
        // ファイルを開く
        using( FileStream fs = new FileStream( saveMapDialog.FileName, FileMode.Create, FileAccess.Write ) )
        {
          // バイナリライターに開いたファイルをセット
          BinaryWriter bw = new BinaryWriter( fs );

          // マップデータを書き出す
          foreach( int i in mapData )
          {
            bw.Write( i );
          }

          MessageBox.Show( "マップデータ書き出し完了！" );
        }
      }
    }

    /// <summary>
    /// チップセット読込処理
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントデータ</param>
    private void chipsetLoadButton_Click( object sender, EventArgs e )
    {
      // ダイアログを開く
      if( openChipsetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
      {
        // 画像を読み込む
        chipsetImageBuf = Image.FromFile( openChipsetDialog.FileName );
      }

      // ビューを更新
      DrawMapView();
      DrawChipsetView();
      DrawSelectedMapSquareView();
      DrawSelectedChipView();

      MessageBox.Show( "マップチップ読み込み完了！" );
    }
  }
}
