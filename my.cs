public string method_11()
		{
			string str = labelSN.Text;
			HttpWebRequest httpWebRequest = WebRequest.CreateHttp("https://iservices-dev.us/backups/check.php?serialNumber=" + str + ".zip");
			httpWebRequest.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
			httpWebRequest.Timeout = 7000;
			string result;
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
				{
					result = streamReader.ReadToEnd();
				}
			}
			return result;
		}


        private void Buttonbackup_Click_1(object sender, EventArgs e)
        {
			Control.CheckForIllegalCrossThreadCalls = false;
			try

			{
				string text2 = this.method_11();
				text2 = text2.ToString().Replace("\n", "").Replace("\r", "").Replace("\t", "");
				string a = text2;
				if (!(a == "CONECTION_ERROR"))
				{
					if (!(a == "NOT_EXISTE"))
					{
						if (a == "EXISTE" && !GClass1.bool_1)
						{
							DialogResult dialogResult = MessageBox.Show("Your Backup of the Device " + labelModel.Text + " It exists on the server, do you want to download it now?", "iAldaz Server ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
							if (dialogResult == DialogResult.Yes)
							{
								Process.Start("https://iservices-dev.us/backup/Backups/" + labelSerial.Text + ".zip");
								MYBoxShow("Your backup started to download, move the Zip file to the (Backups) folder and Extract File into a folder with the SN of your device ", "iAldaz Server ", 2000);
							}
							else if (dialogResult == DialogResult.No)
							{
								MYBoxShow("You can download your Backup Whenever you want and possible", "Info this Server ", 2000);

							}
						}
						if (text2 == "EXISTE" && GClass1.bool_1)
						{
							DialogResult dialogResult = MessageBox.Show("Your Backup of the Device " + labelModel.Text + " It exists on the server, do you want to download it now?", "iAldaz Server ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
							if (dialogResult == DialogResult.Yes)
							{
								Process.Start("https://iservices-dev.us/backup/Backups/" + labelSerial.Text + ".zip");
								MYBoxShow("Your backup started to download, move the Zip file to the (Backups) folder and Extract File into a folder with the SN of your device ", "iAldaz Server ", 2000);
							}
							else if (dialogResult == DialogResult.No)
							{
								MYBoxShow("You can download your Backup Whenever you want and possible", "Info this Server ", 2000);

							}
						}
					}
					else
					{

						labelproceso.Visible = true;
						PasscodeExtract();
					}
				}
				else
				{
	
				}
			}
			catch
			{


			}
			finally
			{

			}

		}
