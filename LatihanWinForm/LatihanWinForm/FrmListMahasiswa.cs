using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatihanWinForm
{
    public partial class FrmListMahasiswa : Form
    {
        //constructor (sebuah method khusus yang namanya sama dengan nama class)
        public FrmListMahasiswa()
        {
            InitializeComponent();

            //memanggil inisialisasi list view
            InisialisasiListView();
        }

        // method untuk membuat fornat list view
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = System.Windows.Forms.View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Npm", 70, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Nama", 180, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Jenis Kelamin", 80, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tempat Lahir", 75, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tgl. Lahir", 75, HorizontalAlignment.Left);
        }


        // method reset form, berfungsi untuk mengosongkan inputan data setelah datanya masuk ke listview
        private void ResetForm()
        {
            mskNpm.Clear();
            txtNama.Clear();
            rdoLakilaki.Checked = true;
            txtTempatLahir.Clear();
            dtpTanggalLahir.Value = DateTime.Today;

            mskNpm.Focus();
        }

        private void FrmListMahasiswa_Load(object sender, EventArgs e)
        {

        }

        // mengatur button simpan
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!mskNpm.MaskFull)
            {
                MessageBox.Show("NPM harus diisi!!!", "Peringatan", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskNpm.Focus();
                return;
            }

            if (!(txtNama.Text.Length > 0))
            {
                MessageBox.Show("Nama harus diisi!!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNama.Focus();
                return;
            }

            var jenisKelamin = rdoLakilaki.Checked ? "Laki-laki" : "Perempuan";

            var result = MessageBox.Show("Apakah data ingin disimpan?", "Konfirmasi", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mskNpm.Text);
                item.SubItems.Add(txtNama.Text);
                item.SubItems.Add(jenisKelamin);
                item.SubItems.Add(txtTempatLahir.Text);
                item.SubItems.Add(dtpTanggalLahir.Value.ToString("dd/MM/yyyy"));

                lvwMahasiswa.Items.Add(item);

                ResetForm(); // memanggil reset form, reset form input     
            }
        }

        // mengatur tombol hapus
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var index = lvwMahasiswa.SelectedIndices[0];
                var nama = lvwMahasiswa.Items[index].SubItems[2].Text;
                var msg = string.Format("Apakah data mahasiswa '{0}' ingin dihapus ?", nama);
                var result = MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    lvwMahasiswa.Items[index].Remove();
                    // melakukan penghitungan jumlah item kemudian jumlah tersebut di lakukan untuk menghasilkan urutan
                    for (var i = 0; i < lvwMahasiswa.Items.Count; i++)
                    {
                        var noUrut = i + 1;
                        lvwMahasiswa.Items[1].SubItems[0].Text = Convert.ToString(noUrut);
                    }
                }

            }
            else // data belum dipilih     
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,                 
                    MessageBoxIcon.Exclamation);
            }

        }

        // mengatur tombol tutup
        private void btnTutup_Click(object sender, EventArgs e)
        {
            var msg = "Apakah Anda yakin ?";

            var result = MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
                this.Close();
        }
        
        // mengatur double klik saat di listview
        private void lvwMahasiswa_DoubleClick(object sender, EventArgs e)
        {
            // fungsi double klik untuk me load data.
            // mengambil dari item kemudian di masukan ke textbox inputan sesuai dengan variabelnya.
            var index = lvwMahasiswa.SelectedIndices[0];
            var npm = lvwMahasiswa.Items[index].SubItems[1].Text;
            var name = lvwMahasiswa.Items[index].SubItems[2].Text;
            var jk = lvwMahasiswa.Items[index].SubItems[3].Text;
            var lahir = lvwMahasiswa.Items[index].SubItems[4].Text;
            var tanggal = lvwMahasiswa.Items[index].SubItems[5].Text;
            mskNpm.Text = npm;
            txtNama.Text = name;
            // di perlukan filter apakah kelamin l/p jika 1 maka rdol ter check, jika p maka rdop ter check.
            if (jk == "Laki-Laki")
            {
                rdoLakilaki.Checked = true;
            }
            else if (jk == "Perempuan")
            {
                rdoPerempuan.Checked = true;
            }
            txtTempatLahir.Text = lahir;
            dtpTanggalLahir.Value = DateTime.Today;
        }

    }
}
