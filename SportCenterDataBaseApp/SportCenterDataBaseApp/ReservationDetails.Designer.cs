namespace SportCenterDataBaseApp
{
    partial class ReservationDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_ReservationId = new System.Windows.Forms.Label();
            this.label_CustomerId = new System.Windows.Forms.Label();
            this.label_CustomerName = new System.Windows.Forms.Label();
            this.label_ComplexName = new System.Windows.Forms.Label();
            this.label_FacilityName = new System.Windows.Forms.Label();
            this.label_CustomerPhone = new System.Windows.Forms.Label();
            this.label_CustomerEmail = new System.Windows.Forms.Label();
            this.label_ReservationDate = new System.Windows.Forms.Label();
            this.label_StartHour = new System.Windows.Forms.Label();
            this.label_EndHour = new System.Windows.Forms.Label();
            this.comboBox_RentalFacilities = new System.Windows.Forms.ComboBox();
            this.label_ChooseRentalFacility = new System.Windows.Forms.Label();
            this.comboBox_Accessories = new System.Windows.Forms.ComboBox();
            this.label_ChooseAccessory = new System.Windows.Forms.Label();
            this.button_SaveReservationAccessory = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_AccessoriesDataGrid = new System.Windows.Forms.Label();
            this.button_DeleteReservationAccessory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ReservationId
            // 
            this.label_ReservationId.AutoSize = true;
            this.label_ReservationId.Location = new System.Drawing.Point(12, 18);
            this.label_ReservationId.Name = "label_ReservationId";
            this.label_ReservationId.Size = new System.Drawing.Size(83, 13);
            this.label_ReservationId.TabIndex = 1;
            this.label_ReservationId.Text = "Rezerwacja ID: ";
            // 
            // label_CustomerId
            // 
            this.label_CustomerId.AutoSize = true;
            this.label_CustomerId.Location = new System.Drawing.Point(12, 38);
            this.label_CustomerId.Name = "label_CustomerId";
            this.label_CustomerId.Size = new System.Drawing.Size(53, 13);
            this.label_CustomerId.TabIndex = 2;
            this.label_CustomerId.Text = "Klient ID: ";
            // 
            // label_CustomerName
            // 
            this.label_CustomerName.AutoSize = true;
            this.label_CustomerName.Location = new System.Drawing.Point(12, 58);
            this.label_CustomerName.Name = "label_CustomerName";
            this.label_CustomerName.Size = new System.Drawing.Size(31, 13);
            this.label_CustomerName.TabIndex = 3;
            this.label_CustomerName.Text = "aaaa";
            // 
            // label_ComplexName
            // 
            this.label_ComplexName.AutoSize = true;
            this.label_ComplexName.Location = new System.Drawing.Point(12, 118);
            this.label_ComplexName.Name = "label_ComplexName";
            this.label_ComplexName.Size = new System.Drawing.Size(59, 13);
            this.label_ComplexName.TabIndex = 5;
            this.label_ComplexName.Text = "Kompleks: ";
            // 
            // label_FacilityName
            // 
            this.label_FacilityName.AutoSize = true;
            this.label_FacilityName.Location = new System.Drawing.Point(12, 138);
            this.label_FacilityName.Name = "label_FacilityName";
            this.label_FacilityName.Size = new System.Drawing.Size(44, 13);
            this.label_FacilityName.TabIndex = 6;
            this.label_FacilityName.Text = "Obiekt: ";
            // 
            // label_CustomerPhone
            // 
            this.label_CustomerPhone.AutoSize = true;
            this.label_CustomerPhone.Location = new System.Drawing.Point(12, 78);
            this.label_CustomerPhone.Name = "label_CustomerPhone";
            this.label_CustomerPhone.Size = new System.Drawing.Size(49, 13);
            this.label_CustomerPhone.TabIndex = 7;
            this.label_CustomerPhone.Text = "Telefon: ";
            // 
            // label_CustomerEmail
            // 
            this.label_CustomerEmail.AutoSize = true;
            this.label_CustomerEmail.Location = new System.Drawing.Point(12, 98);
            this.label_CustomerEmail.Name = "label_CustomerEmail";
            this.label_CustomerEmail.Size = new System.Drawing.Size(38, 13);
            this.label_CustomerEmail.TabIndex = 8;
            this.label_CustomerEmail.Text = "Email: ";
            // 
            // label_ReservationDate
            // 
            this.label_ReservationDate.AutoSize = true;
            this.label_ReservationDate.Location = new System.Drawing.Point(12, 158);
            this.label_ReservationDate.Name = "label_ReservationDate";
            this.label_ReservationDate.Size = new System.Drawing.Size(86, 13);
            this.label_ReservationDate.TabIndex = 9;
            this.label_ReservationDate.Text = "Data rezerwacji: ";
            // 
            // label_StartHour
            // 
            this.label_StartHour.AutoSize = true;
            this.label_StartHour.Location = new System.Drawing.Point(12, 178);
            this.label_StartHour.Name = "label_StartHour";
            this.label_StartHour.Size = new System.Drawing.Size(112, 13);
            this.label_StartHour.TabIndex = 10;
            this.label_StartHour.Text = "Godzina rozpoczęcia: ";
            // 
            // label_EndHour
            // 
            this.label_EndHour.AutoSize = true;
            this.label_EndHour.Location = new System.Drawing.Point(12, 198);
            this.label_EndHour.Name = "label_EndHour";
            this.label_EndHour.Size = new System.Drawing.Size(115, 13);
            this.label_EndHour.TabIndex = 11;
            this.label_EndHour.Text = "Godzina zakończenia: ";
            // 
            // comboBox_RentalFacilities
            // 
            this.comboBox_RentalFacilities.FormattingEnabled = true;
            this.comboBox_RentalFacilities.Location = new System.Drawing.Point(18, 257);
            this.comboBox_RentalFacilities.Name = "comboBox_RentalFacilities";
            this.comboBox_RentalFacilities.Size = new System.Drawing.Size(121, 21);
            this.comboBox_RentalFacilities.TabIndex = 12;
            this.comboBox_RentalFacilities.SelectedIndexChanged += new System.EventHandler(this.ComboBox_RentalFacilities_onChange);
            // 
            // label_ChooseRentalFacility
            // 
            this.label_ChooseRentalFacility.AutoSize = true;
            this.label_ChooseRentalFacility.Location = new System.Drawing.Point(18, 235);
            this.label_ChooseRentalFacility.Name = "label_ChooseRentalFacility";
            this.label_ChooseRentalFacility.Size = new System.Drawing.Size(116, 13);
            this.label_ChooseRentalFacility.TabIndex = 13;
            this.label_ChooseRentalFacility.Text = "Wybierz wypożyczalnię";
            // 
            // comboBox_Accessories
            // 
            this.comboBox_Accessories.FormattingEnabled = true;
            this.comboBox_Accessories.Location = new System.Drawing.Point(18, 309);
            this.comboBox_Accessories.Name = "comboBox_Accessories";
            this.comboBox_Accessories.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Accessories.TabIndex = 14;
            // 
            // label_ChooseAccessory
            // 
            this.label_ChooseAccessory.AutoSize = true;
            this.label_ChooseAccessory.Location = new System.Drawing.Point(18, 287);
            this.label_ChooseAccessory.Name = "label_ChooseAccessory";
            this.label_ChooseAccessory.Size = new System.Drawing.Size(102, 13);
            this.label_ChooseAccessory.TabIndex = 15;
            this.label_ChooseAccessory.Text = "Wybierz akcesorium";
            // 
            // button_SaveReservationAccessory
            // 
            this.button_SaveReservationAccessory.Location = new System.Drawing.Point(18, 339);
            this.button_SaveReservationAccessory.Name = "button_SaveReservationAccessory";
            this.button_SaveReservationAccessory.Size = new System.Drawing.Size(121, 23);
            this.button_SaveReservationAccessory.TabIndex = 16;
            this.button_SaveReservationAccessory.Text = "Zapisz akcesorium";
            this.button_SaveReservationAccessory.UseVisualStyleBackColor = true;
            this.button_SaveReservationAccessory.Click += new System.EventHandler(this.Button_SaveReservationAccessory_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(241, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(451, 150);
            this.dataGridView1.TabIndex = 17;
            // 
            // label_AccessoriesDataGrid
            // 
            this.label_AccessoriesDataGrid.AutoSize = true;
            this.label_AccessoriesDataGrid.Location = new System.Drawing.Point(238, 18);
            this.label_AccessoriesDataGrid.Name = "label_AccessoriesDataGrid";
            this.label_AccessoriesDataGrid.Size = new System.Drawing.Size(172, 13);
            this.label_AccessoriesDataGrid.TabIndex = 18;
            this.label_AccessoriesDataGrid.Text = "Akcesoria przypisane do rezweracji";
            // 
            // button_DeleteReservationAccessory
            // 
            this.button_DeleteReservationAccessory.Location = new System.Drawing.Point(241, 198);
            this.button_DeleteReservationAccessory.Name = "button_DeleteReservationAccessory";
            this.button_DeleteReservationAccessory.Size = new System.Drawing.Size(228, 23);
            this.button_DeleteReservationAccessory.TabIndex = 19;
            this.button_DeleteReservationAccessory.Text = "Usuń zaznaczoną rezerwację akcesorium";
            this.button_DeleteReservationAccessory.UseVisualStyleBackColor = true;
            // 
            // ReservationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_DeleteReservationAccessory);
            this.Controls.Add(this.label_AccessoriesDataGrid);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_SaveReservationAccessory);
            this.Controls.Add(this.label_ChooseAccessory);
            this.Controls.Add(this.comboBox_Accessories);
            this.Controls.Add(this.label_ChooseRentalFacility);
            this.Controls.Add(this.comboBox_RentalFacilities);
            this.Controls.Add(this.label_EndHour);
            this.Controls.Add(this.label_StartHour);
            this.Controls.Add(this.label_ReservationDate);
            this.Controls.Add(this.label_CustomerEmail);
            this.Controls.Add(this.label_CustomerPhone);
            this.Controls.Add(this.label_FacilityName);
            this.Controls.Add(this.label_ComplexName);
            this.Controls.Add(this.label_CustomerName);
            this.Controls.Add(this.label_CustomerId);
            this.Controls.Add(this.label_ReservationId);
            this.Name = "ReservationDetails";
            this.Text = "ReservationDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ReservationId;
        private System.Windows.Forms.Label label_CustomerId;
        private System.Windows.Forms.Label label_CustomerName;
        private System.Windows.Forms.Label label_ComplexName;
        private System.Windows.Forms.Label label_FacilityName;
        private System.Windows.Forms.Label label_CustomerPhone;
        private System.Windows.Forms.Label label_CustomerEmail;
        private System.Windows.Forms.Label label_ReservationDate;
        private System.Windows.Forms.Label label_StartHour;
        private System.Windows.Forms.Label label_EndHour;
        private System.Windows.Forms.ComboBox comboBox_RentalFacilities;
        private System.Windows.Forms.Label label_ChooseRentalFacility;
        private System.Windows.Forms.ComboBox comboBox_Accessories;
        private System.Windows.Forms.Label label_ChooseAccessory;
        private System.Windows.Forms.Button button_SaveReservationAccessory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_AccessoriesDataGrid;
        private System.Windows.Forms.Button button_DeleteReservationAccessory;
    }
}