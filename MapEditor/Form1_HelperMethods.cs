using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
  public partial class Form1 : Form
  {
    /// <summary>
    /// 選択中マスと選択中チップデータを参照して、マップデータへチップ情報を書き込み、マップバッファを更新する
    /// </summary>
    private void LocateChip()
    {
      // 現在置かれているチップと、新しく置かれるチップが同じなら、何もしない
      if( mapData[selectedMapSquareID] == selectedChipID ) return;

      // マップデータに書き込み（チップを設置）
      mapData[selectedMapSquareID] = selectedChipID;

      // マップバッファ更新
      DrawMapBuf( selectedMapSquareID );
    }

    /// <summary>
    /// 全てのマップデータを参照し、マップバッファの全体の描画を行う
    /// </summary>
    private void DrawMapBuf()
    {
      // グラフィックスの作成 
      using( Graphics g = Graphics.FromImage( mapImageBuf ) )
      {
        // 配列要素の数だけ繰り返す
        for( int i = 0; i < mapData.Length; i++ )
        {
          // マスの座標を求める
          Point mapSquarePos = mapSquareIDToPos( i ); // 描画先となるマップ上のマスの左上座標
          Point chipPos = chipIDToPos( mapData[i] );  // 描画元となるチップセット上のマスの左上座標

          // 描画先・描画元四角形を求める
          Rectangle destRect = new Rectangle( mapSquarePos, chipSize );
          Rectangle srcRect = new Rectangle( chipPos, chipSize );

          // 描画
          g.DrawImage( chipsetView.Image, destRect, srcRect, GraphicsUnit.Pixel );
        }
      }
    }

    /// <summary>
    /// マップスクエアIDを用いてマップデータを参照し、マップバッファの一部分のみ描画を行う
    /// </summary>
    private void DrawMapBuf( int mapSquareID )
    {
      // グラフィックスの作成 
      using( Graphics g = Graphics.FromImage( mapImageBuf ) )
      {
        // マスの座標を求める
        Point mapSquarePos = mapSquareIDToPos( mapSquareID ); // 描画先となるマップ上のマスの左上座標
        Point chipPos = chipIDToPos( selectedChipID );        // 描画元となるチップセット上のマスの左上座標

        // 描画先・描画元四角形を求める
        Rectangle destRect = new Rectangle( mapSquarePos, chipSize );
        Rectangle srcRect = new Rectangle( chipPos, chipSize );

        // 描画
        g.DrawImage( chipsetView.Image, destRect, srcRect, GraphicsUnit.Pixel );
      }
    }

    /// <summary>
    /// マップバッファを参照してマップビュー全体を描画する
    /// </summary>
    private void DrawMapView()
    {
      // マップビューのイメージにマップバッファの内容をコピー
      using( Graphics g = Graphics.FromImage( mapView.Image ) )
      {
        g.DrawImage( mapImageBuf, new Point() );
      }

      // マップビューのイメージに選択中のマスを囲う赤四角形を描画 
      using( Graphics g = Graphics.FromImage( mapView.Image ) )
      {
        Point point = mapSquareIDToPos( selectedMapSquareID );
        Rectangle rect = new Rectangle( point, chipSize );
        g.DrawRectangle( Pens.Red, rect );
      }

      // 描画を反映
      mapView.Refresh();
    }

    /// <summary>
    /// 選択中マスデータを参照して、選択中マスビューを描画する
    /// </summary>
    private void DrawSelectedMapSquareView()
    {
      // グラフィックスの作成 
      using( Graphics g = Graphics.FromImage( selectedMapSquareView.Image ) )
      {
        // 描画元となるチップの左上座標を求める
        Point chipPos = chipIDToPos( mapData[selectedMapSquareID] );

        // 描画先・描画元四角形を求める
        Rectangle destRect = new Rectangle( new Point(), selectedMapSquareView.Size );
        Rectangle srcRect = new Rectangle( chipPos, chipSize );

        // 描画
        g.DrawImage( chipsetView.Image, destRect, srcRect, GraphicsUnit.Pixel );
      }

      // 描画を反映
      selectedMapSquareView.Refresh();
    }

    /// <summary>
    /// 選択中チップデータを参照して、選択中チップビューを描画する
    /// </summary>
    private void DrawSelectedChipView()
    {
      // グラフィックスの作成 
      using( Graphics g = Graphics.FromImage( selectedChipView.Image ) )
      {
        // 描画元となるチップの左上座標を求める
        Point chipPos = chipIDToPos( selectedChipID );

        // 描画先・描画元四角形を求める
        Rectangle destRect = new Rectangle( new Point(), selectedChipView.Size );
        Rectangle srcRect = new Rectangle( chipPos, chipSize );

        // 描画
        g.DrawImage( chipsetView.Image, destRect, srcRect, GraphicsUnit.Pixel );
      }

      // 描画を反映
      selectedChipView.Refresh();
    }

    /// <summary>
    /// マップマスIDから、マップ画像上でのマスの座標を求める
    /// </summary>
    /// <param name="id">マップのマスのID</param>
    /// <returns>マスの座標</returns>
    private Point mapSquareIDToPos( int id )
    {
      return new Point( id % mapGridSize.Width * chipSize.Width, id / mapGridSize.Height * chipSize.Height );
    }

    /// <summary>
    /// チップIDから、チップセット上でのチップの座標を求める
    /// </summary>
    /// <param name="id">チップのID</param>
    /// <returns>チップの座標</returns>
    private Point chipIDToPos( int id )
    {
      return new Point( id % chipsetGridSize.Width * chipSize.Width, id / chipsetGridSize.Height * chipSize.Height );
    }  
  }
}
