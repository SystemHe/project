using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ChangeFileName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (lBoxMenu.Items.Count > 0)
            {
                if (rbtnStart.Checked)
                {
                    RepeatFile(lBoxMenu, 0, "", "", "", progressBar1);//在文件名前加编号
                }
                else if (rbtnEnd.Checked)
                {
                    RepeatFile(lBoxMenu, 1, "", "", "", progressBar1);//在文件名后加编号
                }
                else if (rbtnExtention.Checked)
                {
                    if (cBoxExtention.Text != "")
                    {
                        //批量修改文件扩展名
                        RepeatFile(lBoxMenu, 2, cBoxExtention.Text, "", "", progressBar1);
                    }
                }
                else if (rbtnTitle.Checked)
                {
                    if (txtOldValue.Text != "" && txtNewValue.Text != "")
                        //批量修改Word文件名及文档标题中相应的文字
                        RepeatFile(lBoxMenu, 3, "", txtOldValue.Text, txtNewValue.Text, progressBar1);
                }
                MessageBox.Show("批量重命名文件成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lBoxMenu.Items.Clear();
            }
            else 
            {
                MessageBox.Show("请选择要重命名的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 批量重命名文件（当文件为Word时，修改标题中的文字）
        /// </summary>
        /// <param name="lbox">显示要重命名文件的listBox控件对象</param>
        /// <param name="intFlag">标识按编号重命名，还是按扩展名重命名</param>
        /// <param name="strExten">要重命名的扩展名</param>
        /// <param name="strOldName">要替换的标题文字</param>
        /// <param name="strNewName">替换后的标题文字</param>
        /// <param name="PBar">进度条</param>
        private void RepeatFile(ListBox lbox, int intFlag, string strExten, string strOldName, string strNewName, ProgressBar PBar)
        {
            FileInfo FInfo = null;
            PBar.Maximum = lbox.Items.Count;//设置进度条最大值
            for (int i = 0; i < lbox.Items.Count; i++)
            {
                string strFile = lbox.Items[i].ToString();//获取要重命名的文件列表
                if (File.Exists(strFile))
                {
                    FInfo = new FileInfo(strFile);
                    string strPath = FInfo.DirectoryName;//获取文件路径
                    string strFName = FInfo.Name;//获取文件名
                    string strExtension = FInfo.Extension;//获取文件扩展名
                    switch (intFlag)
                    { 
                        case 0://在文件名前加编号
                            File.Move(strFile,strPath+"\\"+i.ToString().PadLeft(4,'0')+strFName);
                            break;
                        case 1://在文件名后加编号
                            File.Move(strFile, strPath + "\\" + strFName.Substring(0, strFName.LastIndexOf(".")) + i.ToString().PadLeft(4,'0') + strExtension);
                            break;
                        case 2://批量修改文件扩展名
                            File.Move(strFile, strPath + "\\" + strFName.Substring(0, strFName.LastIndexOf(".")) + "." + strExten);
                            break;
                        case 3://如果修改的文件为Word文件
                            frmRepeat frmrepeat = new frmRepeat();
                            object strNewPath = strPath + "\\" + strFName.Replace(strOldName, strNewName);
                            File.Move(strFile, strNewPath.ToString());
                            if (strFName.ToLower() == ".doc")
                            {
                                //若文件为Word文档格式则替换标题中的文字
                                Microsoft.Office.Interop.Word.Application newWord = new Microsoft.Office.Interop.Word.Application();
                                object missing = System.Reflection.Missing.Value;
                                //打开一个Word文档
                                Microsoft.Office.Interop.Word.Document newDocument = newWord.Documents.Open(ref strNewPath,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing );
                                object Replaceone = Microsoft.Office.Interop.Word.WdReplace.wdReplaceOne;
                                //设置要查找的关键字
                                newWord.Selection.Find.ClearFormatting();
                                newWord.Selection.Find.Text = strOldName;
                                //设置要替换的关键字
                                newWord.Selection.Find.Replacement.ClearFormatting();
                                newWord.Selection.Find.Replacement.Text = strNewName;
                                newWord.Selection.Find.Execute(ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref Replaceone,ref missing,ref missing,ref missing,ref missing);
                                //保存Word文档
                                newWord.ActiveDocument.Save();
                                //关闭Word文档
                                object objSaveChange = Microsoft.Office.Interop.Word.WdSaveOptions.wdSaveChanges;
                                Microsoft.Office.Interop.Word.DocumentClass doc = newWord.ActiveDocument as Microsoft.Office.Interop.Word.DocumentClass;
                                doc.Close(ref objSaveChange,ref missing,ref missing);
                            }
                            break;
                    }
                    PBar.Value = i + 1;
                }
            }
        }

        private class IconIndexes  
        {  
            public const int MyComputer = 0;      //我的电脑  
            public const int ClosedFolder = 1;    //文件夹关闭  
            public const int OpenFolder = 2;      //文件夹打开  
            public const int FixedDrive = 3;      //磁盘盘符  
            public const int MyDocuments = 4;     //我的文档  
        }  

        private void Form1_Load(object sender, EventArgs e)
        {
        ////实例化TreeNode类 TreeNode(string text,int imageIndex,int selectImageIndex)              
        //    TreeNode rootNode = new TreeNode("我的电脑",  
        //    IconIndexes.MyComputer, IconIndexes.MyComputer);  //载入显示 选择显示  
        //    rootNode.Tag = "我的电脑";                            //树节点数据  
        //    rootNode.Text = "我的电脑";                           //树节点标签内容  
        //    this.tvMenu.Nodes.Add(rootNode);               //树中添加根目录  
  
        //    //显示MyDocuments(我的文档)结点  
        //    var myDocuments = Environment.GetFolderPath           //获取计算机我的文档文件夹  
        //        (Environment.SpecialFolder.MyDocuments);  
        //    TreeNode DocNode = new TreeNode(myDocuments);  
        //    DocNode.Tag = "我的文档";                            //设置结点名称  
        //    DocNode.Text = "我的文档";  
        //    DocNode.ImageIndex = IconIndexes.MyDocuments;         //设置获取结点显示图片  
        //    DocNode.SelectedImageIndex = IconIndexes.MyDocuments; //设置选择显示图片  
        //    rootNode.Nodes.Add(DocNode);                          //rootNode目录下加载节点  
        //    DocNode.Nodes.Add("");  
  
        //    //循环遍历计算机所有逻辑驱动器名称(盘符)  
        //    foreach (string drive in Environment.GetLogicalDrives())  
        //    {  
        //        //实例化DriveInfo对象 命名空间System.IO  
        //        var dir = new DriveInfo(drive);  
        //        switch (dir.DriveType)           //判断驱动器类型  
        //        {  
        //            case DriveType.Fixed:        //仅取固定磁盘盘符 Removable-U盘   
        //                {  
        //                    //Split仅获取盘符字母  
        //                    TreeNode tNode = new TreeNode(dir.Name.Split(':')[0]);  
        //                    tNode.Name = dir.Name;  
        //                    tNode.Tag = tNode.Name;  
        //                    tNode.ImageIndex = IconIndexes.FixedDrive;         //获取结点显示图片  
        //                    tNode.SelectedImageIndex = IconIndexes.FixedDrive; //选择显示图片  
        //                    tvMenu.Nodes.Add(tNode);                    //加载驱动节点  
        //                    tNode.Nodes.Add("");                            
        //                }  
        //                break;  
        //        }  
        //    }  
        //    rootNode.Expand();  
            DirectoryInfo theFolder = new DirectoryInfo(@"E:\");
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in dirInfo)
            {
                // this.listBox1.Items.Add(NextFolder.Name);
                FileInfo[] fileInfo = NextFolder.GetFiles();
                foreach (FileInfo NextFile in fileInfo)  //遍历文件,获取文件名
                    this.tvMenu.Nodes.Add(NextFile.Name);
            }


        }

        //private void tvMenu_AfterExpand(object sender, TreeViewEventArgs e)
        //{
        //    e.Node.Expand();
        //}

        //private void tvMenu_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        //{
        //    TreeViewItems.Add(e.Node);
        //}
        //public static class TreeViewItems  
        //{  
        //    public static void Add(TreeNode e)  
        //    {  
        //        //try..catch异常处理  
        //        try  
        //        {  
        //            //判断"我的电脑"Tag 上面加载的该结点没指定其路径  
        //            if (e.Tag.ToString() != "我的电脑")  
        //            {  
        //                e.Nodes.Clear();                               //清除空节点再加载子节点  
        //                TreeNode tNode = e;                            //获取选中\展开\折叠结点  
        //                string path = tNode.Name;                      //路径    
  
        //                //获取"我的文档"路径  
        //                if (e.Tag.ToString() == "我的文档")  
        //                {  
        //                    path = Environment.GetFolderPath           //获取计算机我的文档文件夹  
        //                    (Environment.SpecialFolder.MyDocuments);  
        //                }  
  
        //                //获取指定目录中的子目录名称并加载结点  
        //            string[] dics = Directory.GetDirectories(path);  
        //                foreach (string dic in dics)  
        //                {  
        //                    TreeNode subNode = new TreeNode(new DirectoryInfo(dic).Name); //实例化  
        //                    subNode.Name = new DirectoryInfo(dic).FullName;               //完整目录  
        //                    subNode.Tag = subNode.Name;  
        //                    subNode.ImageIndex = IconIndexes.ClosedFolder;       //获取节点显示图片  
        //                    subNode.SelectedImageIndex = IconIndexes.OpenFolder; //选择节点显示图片  
        //                    tNode.Nodes.Add(subNode);  
        //                    subNode.Nodes.Add("");                               //加载空节点 实现+号  
        //                }  
        //            }  
        //        }  
        //        catch (Exception msg)  
        //        {  
        //            MessageBox.Show(msg.Message);                   //异常处理  
        //        }  
        //    }  
        //}

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string str = tvMenu.SelectedNode.ToString().Substring(10, tvMenu.SelectedNode.ToString().Length - 10);
            lBoxMenu.Items.Add(str);
        }

        private void btnCSelect_Click(object sender, EventArgs e)
        {
            if(lBoxMenu.SelectedIndex!=-1)
            lBoxMenu.Items.Remove(lBoxMenu.SelectedItem);
        }

        private void btnDSelect_Click(object sender, EventArgs e)
        {

        }

    }
}
