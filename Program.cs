﻿
using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
 
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string strBPC = @"BPC/";
            string str = "";
           
            
            HelpYou hy = new HelpYou();


          
            // 
            do
            {
                // xoa man hinh
                Console.Clear();
                

                str = Console.ReadLine();
                
                
                
            }while(str != "exit");
        }
        

    }
    class HelpYou{
        // tao thu muc
        public void TaoThuMuc(string nameFolder){
            // 1. Đường dẫn tới thư mục cần tạo New Directory
            string directoryPath = nameFolder;
            // 2.Khai báo một thể hiện của lớp DirectoryInfo
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            // Kiểm tra thư mục chưa tồn tại mới sử dụng phương thức tạo
            if (!directory.Exists)
                // 3.Sử dụng phương thức Create để tạo thư mục.
                directory.Create();
        }
        // tao file
        public void TaoFile(string nameFile){
            // neu file chua co
            if (File.Exists(nameFile) == false){
                // sử dụng hàm tạo của lớp FileStream
                FileStream fs = new FileStream(nameFile, FileMode.Create);
                fs.Close();
            }
        }
        // tao file
        public void TaoFileVsSuaLoi(string nameFile, int num){
            // neu file chua co
            if (File.Exists(nameFile) == false){
                // sử dụng hàm tạo của lớp FileStream
                FileStream fs = new FileStream(nameFile, FileMode.Create);
                fs.Close();
                StreamWriter sWriter = new StreamWriter(nameFile,true);//fs là 1 FileStream 
                sWriter.Write(1 - num);
                sWriter.Close();
            }
        }
        // ghi du lieu vao file
        public void GhiFile(string nameFile,string data,bool bl){
            // neu file da co
            if(File.Exists(nameFile) == true){
                // sử dụng hàm tạo của lớp FileStream
                StreamWriter sWriter = new StreamWriter(nameFile,bl);//fs là 1 FileStream 
                sWriter.Write(data);
                sWriter.Close();
            }
        }
        // ghi du lieu vao file voi 1 noi dung duy nhat (loc cac ky tu giong nhau)
        public void GhiFileDuyNhat(string nameFile,string data,bool bl){
            bool b = true;
            // neu file da co
            if(File.Exists(nameFile) == true){
                // // sử dụng hàm tạo của lớp FileStream
                
                // doc file
                string[] rF = File.ReadAllLines(nameFile);
                foreach(string r in rF){
                    // kiem tra du lieu
                    if(data.Replace(" ","").ToLower() == r.Replace(" ","").ToLower())
                        b = false;
                        
                    // Console.WriteLine(r+ " = " + data + " = " +  b);
                }
                // Console.ReadKey();
                if(b == true){
                    StreamWriter sWriter = new StreamWriter(nameFile,bl);//fs là 1 FileStream 
                    sWriter.Write(data + "\n");
                    sWriter.Close();
                }
            }
        }
        // ghi du lieu vao file voi 1 noi dung duy nhat (loc cac ky tu giong nhau)
        public string ThongKeDuLieuConLai(string nameFile,string nameFile1){
            string str = "";
            bool b = false;
            // neu file da co
            if(File.Exists(nameFile) == true){
                // // sử dụng hàm tạo của lớp FileStream
                
                // doc file
                string[] rF = File.ReadAllLines(nameFile);
                foreach(string r in rF){
                    b = false;
                     // doc file
                    string[] rF1 = File.ReadAllLines(nameFile1);
                    foreach(string r1 in rF1){
                        // kiem tra du lieu
                        if(r1.Replace(" ","").ToLower() == r.Replace(" ","").ToLower())
                            b = true;
                       
                        
                    }
                    // lay ra cong ban chua lam
                    if(b == false){
                        str =  str + r;
                    }
                     
                }
            
                
                // Console.ReadKey();
            }
            return str;
        }
        // ghi du lieu vao file voi 1 noi dung duy nhat (tra ve cac ky tu giong nhau)
        public string ThongKeDuLieuGiongNhau(string nameFile,string nameFile1){
            string str = "";
            bool b = false;
            // neu file da co
            if(File.Exists(nameFile) == true){
                // // sử dụng hàm tạo của lớp FileStream
                
                // doc file
                string[] rF = File.ReadAllLines(nameFile);
                foreach(string r in rF){
                    b = false;
                     // doc file
                    string[] rF1 = File.ReadAllLines(nameFile1);
                    foreach(string r1 in rF1){
                        // kiem tra du lieu
                        if(r1.Replace(" ","").ToLower() == r.Replace(" ","").ToLower())
                            b = true;

                        
                    }
                    // lay ra cong ban chua lam
                    if(b == true){
                        str =  str + r;
                    }
                     
                }
            
                
                // Console.ReadKey();
            }
            return str;
        }
        // doc du lieu trong file
        public string DocFile(string nameFile){
            string text = "...";
            // neu file co ton tai
            if(File.Exists(nameFile) == true)
                text = File.ReadAllText(nameFile);
            return text;
        }
        // doc du lieu trong file va tra ve vi tri can tim
        public string DocFileVsFind(string nameFile,string strFind){
            string text = "...";
            // neu file co ton tai
            string[] lines = File.ReadAllLines(nameFile);
            foreach(string s in lines){
                if(s.Contains(strFind))
                    text = text + "> " + s + " <\n";
                else
                    text = text + s + "\n";
            }
            return text;
        }
        // doc du lieu trong file va tra ve gia tri can tim
        public string DocFileVsReturnValueFind(string nameFile,string strFind){
            string text = "...";
            // neu file co ton tai
            string[] lines = File.ReadAllLines(nameFile);
            foreach(string s in lines){
                if(strFind.Contains(s))
                    text = s; 
            }
            return text;
        }
        // doc du lieu trong file va tra ve gia tri can tim
        public bool DocFileRTF(string nameFile,string strFind){
            bool bTF = false;
            // neu file co ton tai
            string[] lines = File.ReadAllLines(nameFile);
            foreach(string s in lines){
                if(strFind.Contains(s))
                    bTF = true;
            }
            return bTF;
        }
        // doc du lieu trong file
        public string DocFileVsNeuDuLieuKhacRong(string data,string nameFile){
            string text = "...";
            // neu file co ton tai
            if(File.Exists(nameFile) == true && data.Replace(" ","") != "")
                text = File.ReadAllText(nameFile);
            return text;
        }
        // liet ke thu muc va file
        public void LietKeFile(string nameFolder){
            if(Directory.Exists(nameFolder) == true){
                string[] rFD = Directory.GetFiles(nameFolder);
                foreach (string f in rFD)
                {
                    Console.WriteLine(f);
                }
                Console.ReadKey();
            }
        }
        // liet ke thu muc va file
        public string KiemTraThuMucVsTen(string nameFolder){
            string nameF = "...";
            if(Directory.Exists(nameFolder) == true)
                nameF = nameFolder.Substring(nameFolder.LastIndexOf("/")+1);
            return nameF;
        }
        // dem ngay
        public string DemNgay(string date1,string date2){
            DateTime ngaymuon = Convert.ToDateTime(date1);
            DateTime ngaytra = Convert.ToDateTime(date2);
            TimeSpan Time = ngaytra - ngaymuon;
            int TongSoNgay = Time.Days;
            return TongSoNgay + "";
        }
        // dem thang
        public string DemThang(DateTime date1,DateTime date2){
            DateTime ngaymuon = Convert.ToDateTime(date1);
            DateTime ngaytra = Convert.ToDateTime(date2);
            TimeSpan Time = ngaytra - ngaymuon;
            int TongSoNgay = Time.Days;
            return (TongSoNgay / 30) + "";
        }
        // dem so dong trong file
        public int DemSoDongTrongFile(string nameFile){
            int num = 0;
            // 
            if(File.Exists(nameFile) == true){
                string[] rF = File.ReadAllLines(nameFile);
                foreach(string line in rF){
                    num++;
                }
            }
            return num;
        }
        // tra ve du lieu ngau nhien trong file
        public string ReturnRandomLineInFile(string nameFile){
            string strT = "";
             // 
            if(File.Exists(nameFile) == true){
                int iNumC = 0;
                int iNumRd = 0;
                Random rd = new Random();
                // dem so dong trong file
                string[] rF = File.ReadAllLines(nameFile);
                foreach(string s in rF){
                    iNumC++;
                }
                iNumRd = rd.Next(0,iNumC);
                iNumC = 0;
                // lay du lieu  string[] rF = File.ReadAllLines(nameFile);
                foreach(string s in rF){
                    if(iNumRd == iNumC)
                        strT = s;
                    iNumC++;
                }
            }
            return strT;
        }
        // hien thi ten thu muc
        public string TenThuMuc(string nameFolder){
            if(Directory.Exists(nameFolder) == true){
                // 2.Khai báo một thể hiện của lớp DirectoryInfo
                DirectoryInfo dr = new DirectoryInfo(nameFolder);
                nameFolder = dr.Name;
            }
            return nameFolder;
        }
        // ve khoang cach
        public void VeKhoangTrong(int num){
            for(int i = 0;i < num / 3;i++){
                Console.Write(" ");
            }
        }
        // dem so luong thu muc
        public int DemThuMuc(string nameFolder){
            int num = 0;
            if(Directory.Exists(nameFolder) == true){
                string[] getD = Directory.GetDirectories(nameFolder);
                foreach(string d in getD){
                    num++;
                }
            }
            return num;
        }
        // mo duong dan
        public string MoDuongDan(string duongDan)
        {
            Process myProcess = new Process();
            try
            {
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = duongDan;
                myProcess.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            return duongDan;
        }
        // ten file
        public string TenFile(string strNameFile){
            // 
            FileInfo file = new FileInfo(strNameFile);
            // Console.WriteLine(file.Name);
            return file.Name;
        }
    }
}