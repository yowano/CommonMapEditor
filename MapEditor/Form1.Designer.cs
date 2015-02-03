namespace MapEditor
{
  partial class Form1
  {
    /// <summary>
    /// 必要なデザイナー変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 使用中のリソースをすべてクリーンアップします。
    /// </summary>
    /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && (components != null) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows フォーム デザイナーで生成されたコード

    /// <summary>
    /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディターで変更しないでください。
    /// </summary>
    private void InitializeComponent()
    {
      this.mapView = new System.Windows.Forms.PictureBox();
      this.chipsetView = new System.Windows.Forms.PictureBox();
      this.selectedMapSquareView = new System.Windows.Forms.PictureBox();
      this.selectedMapSquareXLabel = new System.Windows.Forms.Label();
      this.selectedMapSquareYLabel = new System.Windows.Forms.Label();
      this.chipsetLoadButton = new System.Windows.Forms.Button();
      this.selectedChipView = new System.Windows.Forms.PictureBox();
      this.mapLoadButton = new System.Windows.Forms.Button();
      this.mapSaveButton = new System.Windows.Forms.Button();
      this.openMapDialog = new System.Windows.Forms.OpenFileDialog();
      this.openChipsetDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
      this.selectedChipXLabel = new System.Windows.Forms.Label();
      this.selectedChipYLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.mapView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chipsetView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.selectedMapSquareView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.selectedChipView)).BeginInit();
      this.SuspendLayout();
      // 
      // mapView
      // 
      this.mapView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.mapView.Location = new System.Drawing.Point(10, 10);
      this.mapView.Name = "mapView";
      this.mapView.Size = new System.Drawing.Size(256, 256);
      this.mapView.TabIndex = 0;
      this.mapView.TabStop = false;
      this.mapView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapView_MouseDown);
      this.mapView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapView_MouseMove);
      this.mapView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapView_MouseUp);
      // 
      // chipsetView
      // 
      this.chipsetView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.chipsetView.Image = global::MapEditor.Properties.Resources._default;
      this.chipsetView.Location = new System.Drawing.Point(282, 10);
      this.chipsetView.Name = "chipsetView";
      this.chipsetView.Size = new System.Drawing.Size(256, 256);
      this.chipsetView.TabIndex = 1;
      this.chipsetView.TabStop = false;
      this.chipsetView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chipsetView_MouseDown);
      // 
      // selectedMapSquareView
      // 
      this.selectedMapSquareView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.selectedMapSquareView.Location = new System.Drawing.Point(10, 272);
      this.selectedMapSquareView.Name = "selectedMapSquareView";
      this.selectedMapSquareView.Size = new System.Drawing.Size(64, 64);
      this.selectedMapSquareView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.selectedMapSquareView.TabIndex = 2;
      this.selectedMapSquareView.TabStop = false;
      // 
      // selectedMapSquareXLabel
      // 
      this.selectedMapSquareXLabel.AutoSize = true;
      this.selectedMapSquareXLabel.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.selectedMapSquareXLabel.Location = new System.Drawing.Point(93, 280);
      this.selectedMapSquareXLabel.Name = "selectedMapSquareXLabel";
      this.selectedMapSquareXLabel.Size = new System.Drawing.Size(48, 24);
      this.selectedMapSquareXLabel.TabIndex = 3;
      this.selectedMapSquareXLabel.Text = "X: 0";
      // 
      // selectedMapSquareYLabel
      // 
      this.selectedMapSquareYLabel.AutoSize = true;
      this.selectedMapSquareYLabel.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.selectedMapSquareYLabel.Location = new System.Drawing.Point(93, 307);
      this.selectedMapSquareYLabel.Name = "selectedMapSquareYLabel";
      this.selectedMapSquareYLabel.Size = new System.Drawing.Size(48, 24);
      this.selectedMapSquareYLabel.TabIndex = 4;
      this.selectedMapSquareYLabel.Text = "Y: 0";
      // 
      // chipsetLoadButton
      // 
      this.chipsetLoadButton.Location = new System.Drawing.Point(450, 272);
      this.chipsetLoadButton.Name = "chipsetLoadButton";
      this.chipsetLoadButton.Size = new System.Drawing.Size(88, 23);
      this.chipsetLoadButton.TabIndex = 5;
      this.chipsetLoadButton.Text = "チップセット読込";
      this.chipsetLoadButton.UseVisualStyleBackColor = true;
      this.chipsetLoadButton.Click += new System.EventHandler(this.chipsetLoadButton_Click);
      // 
      // selectedChipView
      // 
      this.selectedChipView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.selectedChipView.Location = new System.Drawing.Point(282, 272);
      this.selectedChipView.Name = "selectedChipView";
      this.selectedChipView.Size = new System.Drawing.Size(64, 64);
      this.selectedChipView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.selectedChipView.TabIndex = 6;
      this.selectedChipView.TabStop = false;
      // 
      // mapLoadButton
      // 
      this.mapLoadButton.Location = new System.Drawing.Point(191, 272);
      this.mapLoadButton.Name = "mapLoadButton";
      this.mapLoadButton.Size = new System.Drawing.Size(75, 23);
      this.mapLoadButton.TabIndex = 7;
      this.mapLoadButton.Text = "マップ読込";
      this.mapLoadButton.UseVisualStyleBackColor = true;
      this.mapLoadButton.Click += new System.EventHandler(this.mapLoadButton_Click);
      // 
      // mapSaveButton
      // 
      this.mapSaveButton.Location = new System.Drawing.Point(191, 301);
      this.mapSaveButton.Name = "mapSaveButton";
      this.mapSaveButton.Size = new System.Drawing.Size(75, 23);
      this.mapSaveButton.TabIndex = 8;
      this.mapSaveButton.Text = "マップ記録";
      this.mapSaveButton.UseVisualStyleBackColor = true;
      this.mapSaveButton.Click += new System.EventHandler(this.mapSaveButton_Click);
      // 
      // openMapDialog
      // 
      this.openMapDialog.FileName = "map_0.map";
      this.openMapDialog.Filter = "マップファイル|*.map|すべてのファイル|*.*";
      // 
      // openChipsetDialog
      // 
      this.openChipsetDialog.FileName = "chipset_0.png";
      this.openChipsetDialog.Filter = "画像ファイル|*.bmp;*.jpg;*.png|全てのファイル|*.*";
      // 
      // saveMapDialog
      // 
      this.saveMapDialog.FileName = "map_0.map";
      this.saveMapDialog.Filter = "マップファイル|*.map|すべてのファイル|*.*";
      // 
      // selectedChipXLabel
      // 
      this.selectedChipXLabel.AutoSize = true;
      this.selectedChipXLabel.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.selectedChipXLabel.Location = new System.Drawing.Point(368, 280);
      this.selectedChipXLabel.Name = "selectedChipXLabel";
      this.selectedChipXLabel.Size = new System.Drawing.Size(48, 24);
      this.selectedChipXLabel.TabIndex = 3;
      this.selectedChipXLabel.Text = "X: 0";
      // 
      // selectedChipYLabel
      // 
      this.selectedChipYLabel.AutoSize = true;
      this.selectedChipYLabel.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.selectedChipYLabel.Location = new System.Drawing.Point(368, 307);
      this.selectedChipYLabel.Name = "selectedChipYLabel";
      this.selectedChipYLabel.Size = new System.Drawing.Size(48, 24);
      this.selectedChipYLabel.TabIndex = 4;
      this.selectedChipYLabel.Text = "Y: 0";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(548, 346);
      this.Controls.Add(this.mapSaveButton);
      this.Controls.Add(this.mapLoadButton);
      this.Controls.Add(this.selectedChipView);
      this.Controls.Add(this.chipsetLoadButton);
      this.Controls.Add(this.selectedChipYLabel);
      this.Controls.Add(this.selectedMapSquareYLabel);
      this.Controls.Add(this.selectedChipXLabel);
      this.Controls.Add(this.selectedMapSquareXLabel);
      this.Controls.Add(this.selectedMapSquareView);
      this.Controls.Add(this.chipsetView);
      this.Controls.Add(this.mapView);
      this.Name = "Form1";
      this.Text = "マップエディタ";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.mapView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chipsetView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.selectedMapSquareView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.selectedChipView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox mapView;
    private System.Windows.Forms.PictureBox chipsetView;
    private System.Windows.Forms.PictureBox selectedMapSquareView;
    private System.Windows.Forms.Label selectedMapSquareXLabel;
    private System.Windows.Forms.Label selectedMapSquareYLabel;
    private System.Windows.Forms.Button chipsetLoadButton;
    private System.Windows.Forms.PictureBox selectedChipView;
    private System.Windows.Forms.Button mapLoadButton;
    private System.Windows.Forms.Button mapSaveButton;
    private System.Windows.Forms.OpenFileDialog openMapDialog;
    private System.Windows.Forms.OpenFileDialog openChipsetDialog;
    private System.Windows.Forms.SaveFileDialog saveMapDialog;
    private System.Windows.Forms.Label selectedChipXLabel;
    private System.Windows.Forms.Label selectedChipYLabel;
  }
}

