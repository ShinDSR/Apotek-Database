using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Apotek_Database
{
    class Program
    {
        public void Create_Tabel()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-OE8BC8L\\DANANGWIBISONO;database=Apotek;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand(
                    //Membuat tabel Obat
                    "create table Obat " +
                    "(Kode_Obat char(7) primary key not null, " +
                    "Nama_Obat varchar(30), " +
                    "Stock_Obat int, " +
                    "Harga_Satuan decimal) " +
                    //Membuat tabel Apoteker 
                    "create table Apoteker " +
                    "(Id_Apoteker char(7) primary key not null, " +
                    "Nama_Apoteker varchar(30), " +
                    "Jenis_Kelamin char(1) Check (Jenis_Kelamin in ('P', 'L')), " +
                    "Kode_Obat char(7) foreign key references Obat(Kode_Obat) not null, " +
                    "Alamat varchar(50), " +
                    "No_Telp char(13))" +
                    //Membuat tabel Supplier
                    "create table Supplier " +
                    "(Id_Supplier char(7) primary key not null, " +
                    "Nama_Supplier varchar(30), " +
                    "Jenis_Kelamin char(1) Check (Jenis_Kelamin in ('P', 'L')), " +
                    "Kode_Obat char(7) foreign key references Obat(Kode_Obat) not null, " +
                    "Alamat varchar(50)," +
                    "No_Telp char(13))" +
                    //Membuat tabel Kasir
                    "create table Kasir " +
                    "(Id_Kasir char(7) primary key not null, " +
                    "Nama_Kasir varchar(30), " +
                    "Jenis_Kelamin char(1) Check (Jenis_Kelamin in ('P', 'L')), " +
                    "Alamat varchar(50), " +
                    "No_Telp char(13))" +
                    //Membuat tabel pembeli
                    "create table Pembeli " +
                    "(Id_Pembeli char(7) primary key not null, " +
                    "Nama_Pembeli varchar(30), " +
                    "No_Telp char(13), " +
                    "Email_Pembeli varchar(30), " +
                    "Alamat varchar(30))" +
                    //Membuat tabel Transaksi
                    "create table Transaksi " +
                    "(Id_Transaksi char(6) primary key not null, " +
                    "Id_Pembeli char(7) foreign key references Pembeli(Id_Pembeli) not null, " +
                    "Id_Kasir char(7) foreign key references Kasir(Id_Kasir) not null, " +
                    "Tanggal date, " +
                    "Waktu time, " +
                    "Total_Qty int , " +
                    "Total_Harga decimal, " +
                    "Jumlah_Bayar decimal, " +
                    "Kembalian decimal)" +
                    //Membuat tabel Detai Transaksi
                    "create table Detail_Transaksi" +
                    "(Id_Detail char(4) primary key not null, " +
                    "Id_Transaksi char(6) foreign key references Transaksi(Id_Transaksi) not null, " +
                    "Kode_Obat char(7) foreign key references Obat(Kode_Obat) not null, " +
                    "Subtotal_Harga decimal, " +
                    "Qty int)", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }

        /*public void InsertData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-OE8BC8L\\DANANGWIBISONO;database=Apotek;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand(
                    //Insert data tabel Obat
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('BTK-001','OB Herbal','10','Rp. 15.000,00')" +
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('INT-001','Insto','10','Rp. 9.000,00')" +
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('PMG-004','Promag','20','Rp. 4.000,00')" +
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('BTK-002','Vicks','10','Rp. 12.000,00')" +
                    "insert into Obat (Kode_Obat, Nama_Obat, Stock_Obat, Harga_Satuan) values ('MKP-001','Minyak Kayu Putih','10','Rp. 15.000,00')" +
                    //Insert data ke tabel Apoteker
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, No_Telp, Alamat) values ('APTK001','Ali Afandi','L','082183653789','Yogyakarta')" +
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, No_Telp, Alamat) values ('APTK002','Safitri','P','085183645669','Yogyakarta')" +
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, No_Telp, Alamat) values ('APTK003','Ahmad Riyad','L','081183653453','Magelang')" +
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, No_Telp, Alamat) values ('APTK004','Muhammand Aziz','L','085452098736','Yogyakarta')" +
                    "insert into Apoteker (Id_Apoteker, Nama_Apoteker, Jenis_Kelamin, No_Telp, Alamat) values ('APTK005','Abdul Hakim','L','082421678543','Solo')" +
                    //Insert data ke tabel Supplier
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, No_Telp, Alamat) values ('SUP-001','Rian Hidayat','L','082224382921','Surabaya')" +
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, No_Telp, Alamat) values ('SUP-002','Ratna Ayu','P','082425650001','Kudus')" +
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, No_Telp, Alamat) values ('SUP-003','Alvian Renaldi','L','085214350798','Bandung')" +
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, No_Telp, Alamat) values ('SUP-004','Putri Aqila','P','082214596820','Jakarta')" +
                    "insert into Supplier (Id_Supplier, Nama_Supplier, Jenis_Kelamin, No_Telp, Alamat) values ('SUP-005','Alamsyah','L','082471239701','Solo')" +
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
                    //Insert data ke tabel Tansaksi
                    "insert into Transaksi (Id_Tansaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Qty_Total, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0001','MBR-003','KAS-005','02-13-2022','08:12:04','2','Rp. 18.000,00','Rp 20.000,00','Rp. 2.000,00')" +
                    "insert into Transaksi (Id_Tansaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Qty_Total, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0002','MBR-001','KAS-005','02-13-2022','08:30:34','1','Rp. 15.000,00','Rp 20.000,00','Rp. 5.000,00')" +
                    "insert into Transaksi (Id_Tansaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Qty_Total, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0003','MBR-004','KAS-002','02-13-2022','09:02:02','1','Rp. 12.000,00','Rp 20.000,00','Rp. 8.000,00')" +
                    "insert into Transaksi (Id_Tansaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Qty_Total, Total_Harga, Jumlah_Bayar, Kembalian) values " +  
                    "('SN0004','MBR-002','KAS-004','02-13-2022','10:47:59','2','Rp. 8.000,00','Rp 10.000,00','Rp. 2.000,00')" +
                    "insert into Transaksi (Id_Tansaksi, Id_Pembeli, Id_Kasir, Tanggal, Waktu, Qty_Total, Total_Harga, Jumlah_Bayar, Kembalian) values " +
                    "('SN0005','MBR-005','KAS-001','02-13-2022','14:42:38','1','Rp. 15.000,00','Rp 50.000,00','Rp. 35.000,00')" +
                    //Insert data ke tabel Detail Transaksi
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('-001','SN0001','INT-001','Rp. 18.000,00','2')" +
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('-002','SN0002','BTK-001','Rp. 15.000,00','1')" +
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('-003','SN0003','BTK-002','Rp. 12.000,00','1')" +
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('-004','SN0004','PMG-004','Rp. 8.000,00','2')" +
                    "insert into Detail_Transaksi (Id_Detail, Id_Transaksi, Kode_Obat, Subtotal_Harga, Qty) values ('-005','SN0005','MKP-001','Rp. 15.000,00','1')", con);
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
        }*/

        static void Main(String[] args)
        {
            new Program().Create_Tabel();
            //new Program().InsertData();
        }
    }
}
