using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Insert
{
    class Program
    {
        public void InsertData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-OE8BC8L\\DANANGWIBISONO;database=Apotek;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand(
                    //Insert data tabel Obat
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('BTK-001','OB Herbal','10','15000.00')" +
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('INT-001','Insto','10','9000.00')" +
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('PMG-004','Promag','20','4000.00')" +
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('BTK-002','Vicks','10','12000.00')" +
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('MKP-001','Minyak Kayu Putih','10','15000.00')" +
                    //Insert data ke tabel Apoteker
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('APTK001','Ali Afandi','L','BTK-001','082183653789','Yogyakarta')" +
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('APTK002','Safitri','P','INT-001','085183645669','Yogyakarta')" +
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('APTK003','Ahmad Riyad','L','PMG-004','081183653453','Magelang')" +
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('APTK004','Muhammand Aziz','L','BTK-002','085452098736','Yogyakarta')" +
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('APTK005','Abdul Hakim','L','MKP-001','082421678543','Solo')" +
                    //Insert data ke tabel Supplier
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('SUP-001','Rian Hidayat','L','BTK-001','082224382921','Surabaya')" +
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('SUP-002','Ratna Ayu','P','INT-001','082425650001','Kudus')" +
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('SUP-003','Alvian Renaldi','L','PMG-004','085214350798','Bandung')" +
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('SUP-004','Putri Aqila','P','BTK-002','082214596820','Jakarta')" +
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, Kode_Obat, No_Telp, Alamat) values ('SUP-005','Alamsyah','L','MKP-001','082471239701','Solo')" +
                    //Insert data ke tabel Kasir
                    "insert into Kasir (Id_Kasir, Nama_Kasir, Jenis_Kelamin, No_Telp, Alamat) values ('KAS-001','Nurdiansyah','L','085382130900','Yogyakarta')" +
                    "insert into Kasir (Id_Kasir, Nama_Kasir, Jenis_Kelamin, No_Telp, Alamat) values ('KAS-002','Ahmad Akmal','L','081345627829','Yogyakarta')" +
                    "insert into Kasir (Id_Kasir, Nama_Kasir, Jenis_Kelamin, No_Telp, Alamat) values ('KAS-003','Aisyah Putri','P','085325719000','Magelang')" +
                    "insert into Kasir (Id_Kasir, Nama_Kasir, Jenis_Kelamin, No_Telp, Alamat) values ('KAS-004','Fitriani','P','081387630976','Magelang')" +
                    "insert into Kasir (Id_Kasir, Nama_Kasir, Jenis_Kelamin, No_Telp, Alamat) values ('KAS-005','Syarifudin','L','082314326758','Yogyakarta')" +
                    //Insert data ke tabel Pembeli
                    "insert into Pembeli (Id_Pembeli, Nama_Pembeli, No_Telp, Email_Pembeli, Alamat) values ('MBR-001','Yusuf Efendi','085023149875','yusufefnd12@gmail.com','Yogyakarta')" +
                    "insert into Pembeli (Id_Pembeli, Nama_Pembeli, No_Telp, Email_Pembeli, Alamat) values ('MBR-002','Hendra Setiawan','081427390912','Hendrastwn098@gmail.com','Yogyakarta')" +
                    "insert into Pembeli (Id_Pembeli, Nama_Pembeli, No_Telp, Email_Pembeli, Alamat) values ('MBR-003','Muhammad Ali','081829301273','mhdali231@gmail.com','Yogyakarta')" +
                    "insert into Pembeli (Id_Pembeli, Nama_Pembeli, No_Telp, Email_Pembeli, Alamat) values ('MBR-004','Wulandari','085315237201','wulan659@gmail.com','Yogyakarta')" +
                    "insert into Pembeli (Id_Pembeli, Nama_Pembeli, No_Telp, Email_Pembeli, Alamat) values ('MBR-005','Ahmad Yusuf','082019362918','amdyusuf009@gmail.com','Yogyakarta')" +
                    ///Insert data ke tabel Tansaksi
                    "insert into Transaksi (Id_Transaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Total_Qty, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0001','MBR-003','KAS-005','02-13-2022','08:12:04','2','18000.00','20000.00','2000.00')" +
                    "insert into Transaksi (Id_Transaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Total_Qty, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0002','MBR-001','KAS-005','02-13-2022','08:30:34','1','15000.00','20000.00','5000.00')" +
                    "insert into Transaksi (Id_Transaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Total_Qty, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0003','MBR-004','KAS-002','02-13-2022','09:02:02','1','12000.00','20000.00','8000.00')" +
                    "insert into Transaksi (Id_Transaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Total_Qty, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0004','MBR-002','KAS-004','02-13-2022','10:47:59','2','8000.00','10000.00','2000.00')" +
                    "insert into Transaksi (Id_Transaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Total_Qty, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0005','MBR-005','KAS-001','02-13-2022','14:42:38','1','15000.00','50000.00','35000.00')" +
                    //Insert data ke tabel Detail Transaksi
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('D001','SN0001','INT-001','18000.00','2')" +
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('D002','SN0002','BTK-001','15000.00','1')" +
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('D003','SN0003','BTK-002','12000.00','1')" +
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('D004','SN0004','PMG-004','8000.00','2')" +
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('D005','SN0005','MKP-001','15000.00','1')", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Data sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah di Memasukkan data. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }

        static void Main(string[] args)
        {
            new Program().InsertData();
        }
    }
}
