//19/02/2024
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
        // tra va bien
        public int ValueInt(string strName)
        {
            // 
            Console.Write(strName);
            _num = int.Parse(Console.ReadLine());
            return _num;
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
    }
}
