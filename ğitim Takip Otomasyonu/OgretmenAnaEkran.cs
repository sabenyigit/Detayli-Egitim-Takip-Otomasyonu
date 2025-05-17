// ... existing code ...
        private async void btnDuyurularYenile_Click(object sender, EventArgs e)
        {
            await ListeleDuyurularAsync();
        }

        private void mesajlaşmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenMesajlasmaForm mesajForm = new OgretmenMesajlasmaForm(ogretmenID);
            mesajForm.Show();
        }

        private void öğrenciİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenIstatistikForm istatistikForm = new OgretmenIstatistikForm(ogretmenID);
            istatistikForm.Show();
        }
// ... existing code ...