//Name Project 07/11/2024 Version
using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
 
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string strSys = @"Sys/";
            string str = "";

            // 
            int[] arrNum = new int[] { };
            string[] arrValue = new string[] { };
 
            // 
            HelpYou hy = new HelpYou();
            Random rd = new Random();
            DateTime dToday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            //
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Red;
         
            // 
            do
            {
                // 
                try{
                    // xoa man hinh
                    Console.Clear();
                    // 
                    str = STR(str,$">",hy);
                    // 
                    CountList(strNameDirectory, arrValue, arrNum, hy);
                // 
                }catch(Exception e){
                    // 
                    Console.WriteLine(e);
                    // 
                    Console.ReadKey();
                }
            // 
            }while(str != "exit");
        }
        // 
        public static string STR(string str,string strName,HelpYou hy){
            // 
            str = hy.Value($"{strName}").ToLower().Replace(" ","");
            // 
            return str;
        }
        // 
        public static void CountList(string strC, string[] arrValue, int[] arrNum, HelpYou hy)
        {
            // 
            if (Directory.Exists(strC) == true)
            {
                // 
                hy.SetCount();
                // 
                arrNum = new int[hy.DemFileTrongThuMuc(strC)];
                arrValue = new string[hy.DemFileTrongThuMuc(strC)];
                // 
                string[] gF = Directory.GetFiles(strC);
                foreach (string f in gF)
                {
                        // 
                        arrNum[hy.GetCount()] = hy.DocFileReturnNum(f);
                        arrValue[hy.GetCount()] = hy.TenFile(f);
                        // 
                        hy.Count();
                }
                // 
                IComparer myComparer = new myReverserClass();
                // Sorts the entire Array using the default comparer.
                // Array.Sort( arrNum, arrValue );
                // Console.WriteLine( "After sorting the entire Array using the default comparer:" );
                // PrintKeysAndValues( arrNum, arrValue );

                // Sorts the entire Array using the reverse case-insensitive comparer.
                Array.Sort(arrNum, arrValue, myComparer);
                // Console.WriteLine( "After sorting the entire Array using the reverse case-insensitive comparer:" );
                Console.WriteLine(" {0,-15}  {1}", "Object", "Days\n ------           ----");
                PrintKeysAndValuesWithNum(arrNum, arrValue,20);
            }
        }
        // 
        // public static void PrintKeysAndValues(int[] myKeys, String[] myValues)
        // {
        //     for (int i = 0; i < myKeys.Length; i++)
        //     {
        //         Console.WriteLine(" {0,-15} +{1}",myValues[i],myKeys[i]);
        //     }
        //     Console.WriteLine();
        // }
        // // 
        public static void PrintKeysAndValuesWithNum(int[] myKeys, String[] myValues,int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(" {0,-15}: {1}",myValues[i],myKeys[i]);
            }
            Console.WriteLine();
        }
        // 
        public static void NewFile(string strF,string str,HelpYou hy){
            // 
            if(File.Exists(strF) == true){
                // 
                if(File.Exists(strF + hy.TenFile(strF)) == true)
                    // 
                    File.Delete(strF + hy.TenFile(strF));
                // 
                hy.TaoFile(strF + hy.TenFile(strF));
                // 
                string[] rF = File.ReadAllLines(strF);
                foreach(string lines in rF){
                    // 
                    if(str != lines)
                        // 
                        hy.GhiFile(strF + hy.TenFile(strF),lines + "\n",true);
                }
                // 
                File.Delete(strF);
                // 
                File.Move(strF + hy.TenFile(strF),strF);
            }
        }
        // 
        public static void Table(string strT,string strC,HelpYou hy){
            //TITLE
            Console.WriteLine("\n┌{0}┐", hy.Draw(hy.CountStr(strT) - 1,'─'));
            // title
            Console.WriteLine("│{0}│",strT);
            // 
            Console.WriteLine("├{0}┤",hy.Draw(hy.CountStr(strT) - 1,'─'));
           
            // CONTENT
            // Console.WriteLine("│{0}│",strC);
            //     
            hy.XepChuoiTratTuCuaTable(strC,'│',hy.CountStr(strT));
            // 
            Console.WriteLine("└{0}┘",hy.Draw(hy.CountStr(strT) - 1,'─'));
        }
        // 
        public static void BackgroundColor(int num){
            // 
            if(num == 0)
                // 
                Console.BackgroundColor = ConsoleColor.Black;
            // 
            if(num == 1)
                // 
                Console.BackgroundColor = ConsoleColor.White;
            // 
            if(num == 2)
                // 
                Console.BackgroundColor = ConsoleColor.Blue;
            // 
            if(num == 3)
                // 
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            // 
            if(num == 4)
                // 
                Console.BackgroundColor = ConsoleColor.Red;
            // 
            if(num == 5)
                // 
                Console.BackgroundColor = ConsoleColor.DarkRed;
            // 
            if(num == 6)
                // 
                Console.BackgroundColor = ConsoleColor.Yellow;
            // 
            if(num == 7)
                // 
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            // 
            if(num == 8)
                // 
                Console.BackgroundColor = ConsoleColor.Gray;
            // 
            if(num == 9)
                // 
                Console.BackgroundColor = ConsoleColor.DarkGray;
            // 
            if(num == 10)
                // 
                Console.BackgroundColor = ConsoleColor.Green;
            // 
            if(num == 11)
                // 
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            // 
            if(num == 12)
                // 
                Console.BackgroundColor = ConsoleColor.Cyan;
            // 
            if(num == 13)
                // 
                Console.BackgroundColor = ConsoleColor.DarkCyan;
            // 
            if(num == 14)
                // 
                Console.BackgroundColor = ConsoleColor.Magenta;
            // 
            if(num == 15)
                // 
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
        }
        // 
        public static void ForegroundColor(int num){
            // 
            if(num == 0)
                // 
                Console.ForegroundColor = ConsoleColor.Black;
            // 
            if(num == 1)
                // 
                Console.ForegroundColor = ConsoleColor.White;
            // 
            if(num == 2)
                // 
                Console.ForegroundColor = ConsoleColor.Blue;
            // 
            if(num == 3)
                // 
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            // 
            if(num == 4)
                // 
                Console.ForegroundColor = ConsoleColor.Red;
            // 
            if(num == 5)
                // 
                Console.ForegroundColor = ConsoleColor.DarkRed;
            // 
            if(num == 6)
                // 
                Console.ForegroundColor = ConsoleColor.Yellow;
            // 
            if(num == 7)
                // 
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            // 
            if(num == 8)
                // 
                Console.ForegroundColor = ConsoleColor.Gray;
            // 
            if(num == 9)
                // 
                Console.ForegroundColor = ConsoleColor.DarkGray;
            // 
            if(num == 10)
                // 
                Console.ForegroundColor = ConsoleColor.Green;
            // 
            if(num == 11)
                // 
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            // 
            if(num == 12)
                // 
                Console.ForegroundColor = ConsoleColor.Cyan;
            // 
            if(num == 13)
                // 
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            // 
            if(num == 14)
                // 
                Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
    // 
    public class myReverserClass : IComparer  {
        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare( Object x, Object y )  {
            return( (new CaseInsensitiveComparer()).Compare( y, x ) );
        }
    }
    // 
    class HelpYou{
        private static int _numCount;
        private int _num;
        private int _num1;
        private string _str;
        private string _strUserName;
        private string _strPassword;
        private string _strChar;
        
        // properties
        public static int NumLineFile
        {
            get
            {
                return _numCount;
            }
            set
            {
                _numCount = value;
            }
        }
        public int Num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = value;
            }
        }
        public int Num1
        {
            get
            {
                return _num1;
            }
            set
            {
                _num1 = value;
            }
        }
        public string Str
        {
            get
            {
                return _str;
            }
            set
            {
                _str = value;
            }
        }
        public string StrUserName
        {
            get
            {
                return _strUserName;
            }
            set
            {
                _strUserName = value;
            }
        }
        public string StrPassword
        {
            get
            {
                return _strPassword;
            }
            set
            {
                _strPassword = value;
            }
        }
        public string StrChar
        {
            get
            {
                return _strChar;
            }
            set
            {
                _strChar = value;
            }
        }
      
        
        // 
        public void SetCount(){
            _numCount = 0;
        }
        public void Count(){
            _numCount++;
        }
        public int GetCount(){
            return _numCount;
        }
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
        public void TaoFileVsSuaLoi(string nameFile, string str){
            // neu file chua co
            if (File.Exists(nameFile) == false){
                // sử dụng hàm tạo của lớp FileStream
                FileStream fs = new FileStream(nameFile, FileMode.Create);
                fs.Close();
                StreamWriter sWriter = new StreamWriter(nameFile,true);//fs là 1 FileStream 
                sWriter.Write(str);
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
            _str = "";
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
                        _str =  _str + r;
                    }
                     
                }
            
                
                // Console.ReadKey();
            }
            return _str;
        }
        // ghi du lieu vao file voi 1 noi dung duy nhat (tra ve cac ky tu giong nhau)
        public string ThongKeDuLieuGiongNhau(string nameFile,string nameFile1){
            _str = "";
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
                        _str =  _str + r;
                    }
                     
                }
            
                
                // Console.ReadKey();
            }
            return _str;
        }
        // doc du lieu trong file
        public string DocFile(string nameFile){
            _str = "...";
            // neu file co ton tai
            if(File.Exists(nameFile) == true)
                _str = File.ReadAllText(nameFile);
            return _str;
        }
        // doc du lieu trong file
        public string DocFileReturnOneLine(string nameFile){
            _str = "";
            // neu file co ton tai
            string[] rF = File.ReadAllLines(nameFile);
            foreach(string str in rF){
                _str = _str + str;
            }
            return _str;
        }
        // doc du lieu trong file
        public string DocFileReturnOneLineWithNumShow(string nameFile,int num1,int num2){
            _str = "";
            _strChar = "";
            _numCount = 0;
            // neu file co ton tai
            string[] rF = File.ReadAllLines(nameFile);
            foreach(string str in rF){
                _str = _str + str;
            }
            // 
            foreach(char ch in _str){
                _numCount++;
                // 
                if(_numCount >= num1 && _numCount <= num2)
                    _strChar = _strChar + ch;
            }
            return _strChar;
        }
        // doc du lieu trong file
        public int DocFileReturnNum(string nameFile)
        {
            // 
            _num = 0;
            // neu file co ton tai
            if (File.Exists(nameFile) == true)
                 // 
                 _num = int.Parse(File.ReadAllText(nameFile));
            // 
            return _num;
        }
        // doc du lieu trong file va tra ve vi tri can tim
        public string DocFileVsFind(string nameFile,string strFind){
            _str = "...";
            // neu file co ton tai
            string[] lines = File.ReadAllLines(nameFile);
            foreach(string s in lines){
                if(s.Contains(strFind))
                    _str = _str + "> " + s + " <\n";
                else
                    _str = _str + s + "\n";
            }
            return _str;
        }
        // doc du lieu trong file va tra ve gia tri can tim
        public string DocFileVsReturnValueFind(string nameFile,string strFind){
            _str = "...";
            // neu file co ton tai
            string[] lines = File.ReadAllLines(nameFile);
            foreach(string s in lines){
                if(strFind.Contains(s))
                    _str = s; 
            }
            return _str;
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
            _str = "...";
            // neu file co ton tai
            if(File.Exists(nameFile) == true && data.Replace(" ","") != "")
                _str = File.ReadAllText(nameFile);
            return _str;
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
            _str = "...";
            if(Directory.Exists(nameFolder) == true)
                _str = nameFolder.Substring(nameFolder.LastIndexOf("/")+1);
            return _str;
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
            _num = 0;
            // 
            if(File.Exists(nameFile) == true){
                string[] rF = File.ReadAllLines(nameFile);
                foreach(string line in rF){
                    _num++;
                }
            }
            return _num;
        }
        // dem ky tu trong file
        public int DemKyTuTrongFile(string nameFile){
            _num = 0;
            _str = "";
            // 
            if(File.Exists(nameFile) == true){
                string[] rF = File.ReadAllLines(nameFile);
                foreach(string line in rF){
                    _str = _str + line;
                }
                // 
                foreach(char ch in _str){
                    _num++;
                }
            }
            return _num;
        }
        // dem ky tu trong file
        public int DemStr(string strSTR)
        {
             _num = 0;
             _str = "";
             // 
             if (strSTR.Replace(" ", "") != "")
             {
                  // 
                  foreach (char ch in strSTR)
                  {
                       _num++;
                  }
             }
             return _num;
        }
        // tra ve du lieu ngau nhien trong file
        public string ReturnRandomLineInFile(string nameFile){
            _str = "";
             // 
            if(File.Exists(nameFile) == true){
                _num = 0;
                _num1 = 0;
                Random rd = new Random();
                // dem so dong trong file
                string[] rF = File.ReadAllLines(nameFile);
                foreach(string s in rF){
                    _num++;
                }
                _num1 = rd.Next(0,_num);
                _num = 0;
                // lay du lieu  string[] rF = File.ReadAllLines(nameFile);
                foreach(string s in rF){
                    if(_num1 == _num)
                        _str = s;
                    _num++;
                }
            }
            return _str;
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
            _num = 0;
            if(Directory.Exists(nameFolder) == true){
                string[] getD = Directory.GetDirectories(nameFolder);
                foreach(string d in getD){
                    _num++;
                }
            }
            return _num;
        }
        // dem so luong thu muc
        public int DemFileTrongThuMuc(string nameFolder){
            _num = 0;
            if(Directory.Exists(nameFolder) == true){
                string[] getD = Directory.GetFiles(nameFolder);
                foreach(string d in getD){
                    _num++;
                }
            }
            return _num;
        }
        // mo duong dan
        public void MoDuongDan(string duongDan)
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
        }
        // ten file
        public string TenFile(string strNameFile){
            // 
            FileInfo file = new FileInfo(strNameFile);
            // Console.WriteLine(file.Name);
            return file.Name;
        }
        // tra va bien
        public string Value(){
            _str = Console.ReadLine();
            return _str;
        }
        // tra va bien
        public string Value(string strName)
        {
            // 
            Console.Write(strName);
            _str = Console.ReadLine();
            return _str;
        }
        // tra va bien so
        public int ValueInt(string strName)
        {
            // 
            Console.Write(strName);
            _num = int.Parse(Console.ReadLine());
            return _num;
        }
       // tra va bien thoi gian ngay thang nam
        public string ValueDate(string strName,DateTime date)
        {
            // Sử dụng TryParseExact để đảm bảo định dạng chính xác
            while (!DateTime.TryParseExact(strName, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                Console.Write("dd/MM/yyyy >");
                strName = Console.ReadLine();
            }
            // 
            return date.ToString("dd/MM/yyyy");
        }
        // dem so ky tu trong chuoi
        public int CountStr(string strC){
            _numCount = 0;
            foreach(char ch in strC){
                _numCount++;
            }
            return _numCount;
        }
        //ve cai qq gi v
        public string Draw(int num,char ch){
            _str = "";
            _str = _str + ch;
            // 
            if(num != 0){
                for(int i = 0;i < num;i++){
                    _str = _str + ch;
                }
            }
            return _str;
        } 
        //ve o vi tri chi dinh
        public string DrawN(int num,int num1,char ch,char ch1){
            _str = "";
            _str = _str + ch;
            // 
            if(num != 0){
                for(int i = 0;i < num;i++){
                    // 
                    if(i == num1)
                         _str = _str + ch1;
                    else
                        _str = _str + ch;
                }
            }
            return _str;
        }
        // xep chuoi thanh nhung ky tu thang hang dung de tu dong xuong dong trong table
        public void XepChuoiTratTuCuaTable(string str,char chDraw,int num){
            _numCount = 0;
            Console.Write(chDraw);
            // 
            foreach(char ch in str){
                // 
                _numCount++;
                // 
                Console.Write(ch);
                // 
                if(_numCount == num){
                    Console.Write(chDraw + "\n" + chDraw);
                    // 
                    _numCount = 0;
                }
                if(ch == '.'){
                    // Console.Write(ch);
                    for(int i = 0;i < num - _numCount;i++){
                        Console.Write(" ");
                    }
                    // 
                    Console.Write(chDraw + "\n" + chDraw);

                    // 
                    _numCount = 0;
                }
            }
            // 
            if(num != 0){
                // 
                for(int i = 0;i < num - _numCount ;i++){
                    Console.Write(" ");
                }
                // 
                Console.WriteLine(chDraw);
            }
        }
        // 
        public bool User(string strF){
            Console.Write("Enter username: ");
            _strUserName = Console.ReadLine();
            _strPassword = "";
            Console.Write("Enter password: ");
            ConsoleKeyInfo keyInfo;
        
            do
            {
                keyInfo = Console.ReadKey(true);
                // Skip if Backspace or Enter is Pressed
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    _strPassword += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && _strPassword.Length > 0)
                    {
                        // Remove last charcter if Backspace is Pressed
                        _strPassword = _strPassword.Substring(0, (_strPassword.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Getting Password Once Enter is Pressed
            while (keyInfo.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Welcome " + _strUserName+",");
            // Console.WriteLine("Your Password is : " + _strPassword);
            if(File.Exists(strF + _strUserName) == true)
                _str = File.ReadAllText(strF +_strUserName);
            // 
            if(_str == _strPassword)
                return true;
            return false;
        }
        // 
        public bool ValueYesNo(string str){
            // 
            ConsoleKeyInfo keyInfo;
            // 
            do
            {
                // 
                Console.Write("\n{0}[Y/N] ",str);
                // 
                keyInfo = Console.ReadKey(true);
            }
            // Stops Getting Password Once Enter is Pressed
            while (keyInfo.Key != ConsoleKey.Y && keyInfo.Key != ConsoleKey.N);
            // 
            if(keyInfo.Key == ConsoleKey.Y)
                // 
                return true;
            // 
            else
                // 
                return false;
        }
        // 
        public void PrintAllDirectory(string dirPath)
        {
            try
            {
                // Nếu bạn không có quyền truy cập thư mục 'dirPath' 
                // một ngoại lệ UnauthorizedAccessException sẽ được ném ra.
                IEnumerable<string> enums = Directory.EnumerateDirectories(dirPath); 
                List<string> dirs = new List<string>(enums); 
                foreach (var dir in dirs)
                {
                    Console.WriteLine(dir); 

                    PrintAllDirectory(dir);
                }
            }
            // Lỗi bảo mật khi truy cập vào thư mục mà bạn không có quyền.
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Can not access directory: " + dirPath);
                Console.WriteLine(e.Message);
            }
        }
        // 
        public void PrintAllFile(string pathfile)
        {
            string[] fileList = Directory.GetFiles(pathfile);//lay danh sách file cho vao mảng
            string strFileName = "";
            //duyet mang file trong thư mục
            foreach (string fileName in fileList)
            {
                strFileName = "";
                strFileName = Path.GetFileName(fileName).Trim();
                ProcessFile(fileName, strFileName);
               
            }

            string[] directorylist = Directory.GetDirectories(pathfile);//lấy danh sách target file cho vào mảng

            //duyệt mảng target
            foreach (string directory in directorylist)
            {
                PrintAllFile(directory);
            }
        }
        // 
        public void ProcessFile(string path,string strfileName)
        {
            Console.WriteLine("{0}", path);
        }
        // 
        public void PrintLargeText(string text)
        {
            // Khai báo mảng để chứa các dòng chữ lớn
            string[] largeTextLines = new string[5];

            foreach (char c in text.ToLower().Replace(" ",""))
            {
                switch (c)
                {
                    case '0':
                        largeTextLines[0] += " 000  ";
                        largeTextLines[1] += "0   0 ";
                        largeTextLines[2] += "0   0 ";
                        largeTextLines[3] += "0   0 ";
                        largeTextLines[4] += " 000  ";
                        break;
                    case '1':
                        largeTextLines[0] += ".1  ";
                        largeTextLines[1] += " 1  ";
                        largeTextLines[2] += " 1  ";
                        largeTextLines[3] += " 1  ";
                        largeTextLines[4] += "111 ";
                        break;
                    case '2':
                        largeTextLines[0] += "222  ";
                        largeTextLines[1] += "   2 ";
                        largeTextLines[2] += "222  ";
                        largeTextLines[3] += "2    ";
                        largeTextLines[4] += "222  ";
                        break;
                    case '3':
                        largeTextLines[0] += "333  ";
                        largeTextLines[1] += "   3 ";
                        largeTextLines[2] += "333  ";
                        largeTextLines[3] += "   3 ";
                        largeTextLines[4] += "333  ";
                        break;
                    case '4':
                        largeTextLines[0] += "4  4 ";
                        largeTextLines[1] += "4  4 ";
                        largeTextLines[2] += "4444 ";
                        largeTextLines[3] += "   4 ";
                        largeTextLines[4] += "   4 ";
                        break;
                    case '5':
                        largeTextLines[0] += "5555 ";
                        largeTextLines[1] += "5    ";
                        largeTextLines[2] += "5555 ";
                        largeTextLines[3] += "   5 ";
                        largeTextLines[4] += "5555 ";
                        break;
                    case '6':
                        largeTextLines[0] += " 666  ";
                        largeTextLines[1] += "6     ";
                        largeTextLines[2] += " 666  ";
                        largeTextLines[3] += "6   6 ";
                        largeTextLines[4] += " 666  ";
                        break;
                    case '7':
                        largeTextLines[0] += "77777 ";
                        largeTextLines[1] += "   7  ";
                        largeTextLines[2] += "  7   ";
                        largeTextLines[3] += " 7    ";
                        largeTextLines[4] += "7     ";
                        break;
                    case '8':
                        largeTextLines[0] += " 888  ";
                        largeTextLines[1] += "8   8 ";
                        largeTextLines[2] += " 888  ";
                        largeTextLines[3] += "8   8 ";
                        largeTextLines[4] += " 888  ";
                        break;
                    case '9':
                        largeTextLines[0] += " 999  ";
                        largeTextLines[1] += "9   9 ";
                        largeTextLines[2] += " 9999 ";
                        largeTextLines[3] += "    9 ";
                        largeTextLines[4] += " 999  ";
                        break;
                    case '.':
                        largeTextLines[0] += "  ";
                        largeTextLines[1] += "  ";
                        largeTextLines[2] += "  ";
                        largeTextLines[3] += "  ";
                        largeTextLines[4] += "# ";
                        break;
                    case '%':
                        largeTextLines[0] += "      ";
                        largeTextLines[1] += "      ";
                        largeTextLines[2] += "O  /  ";
                        largeTextLines[3] += "  /   ";
                        largeTextLines[4] += " /  O";
                        break;
                    case ':':
                        largeTextLines[0] += "    ";
                        largeTextLines[1] += " #  ";
                        largeTextLines[2] += "    ";
                        largeTextLines[3] += " #  ";
                        largeTextLines[4] += "    ";
                        break;
                    // Bạn có thể thêm các chữ cái khác ở đây
                    default:
                        Console.WriteLine("Chữ cái không được hỗ trợ: " + c);
                        break;
                }
            }

            // In ra các dòng chữ lớn
            foreach (string line in largeTextLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
