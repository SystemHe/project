using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace PowerCalendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string ForignTimeNow = "";
        private static ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
        public const string CelestialStem = "甲乙丙丁戊己庚辛壬癸";
        public const string TerrestialBranch = "子丑寅卯辰巳午未申酉戌亥";
        public const string TreeYear = "鼠牛虎免龙蛇马羊猴鸡狗猪" ;
        public static readonly string[] ChineseDayName = new string[] {
            "初一","初二","初三","初四","初五","初六","初七","初八","初九","初十",
            "十一","十二","十三","十四","十五","十六","十七","十八","十九","二十",
            "廿一","廿二","廿三","廿四","廿五","廿六","廿七","廿八","廿九","三十"};
        public static readonly string[] ChineseMonthName = new string[] { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二" };
        private void Form1_Load(object sender, EventArgs e)
        {
            string intMonth = monthCalendar1.TodayDate.Month.ToString();//当前月份
            string intdate = monthCalendar1.TodayDate.Day.ToString();//当前日期
            if (monthCalendar1.TodayDate.Month < 10)//判断月份是否小于10
            {
                intMonth = "0" + monthCalendar1.TodayDate.Month.ToString();//将月份格式化为两位
            }
            if (monthCalendar1.TodayDate.Day < 10)//判断日期是否为两位
            {
                intdate = "0" + monthCalendar1.TodayDate.Day.ToString();//将日期格式化为两位
            }
            //将当前日期转换为中国农历日期
            string s = string.Format("{0}年{1}月{2}", GetStemBench(monthCalendar1.TodayDate), GetMonth(monthCalendar1.TodayDate), GetDay(monthCalendar1.TodayDate));
            //在label控件中显示当前日期对应的农历日期
            label1.Text = monthCalendar1.TodayDate.Year + "年" + intMonth + "月" + intdate + "日"+"  "+s+" "+GetReturnYear(monthCalendar1.TodayDate)+"年";
            label1.ForeColor = Color.Green;//label控件中的字体颜色
        }

        private string GetReturnYear(DateTime time)
        {
            int sexagenaryYear = calendar.GetSexagenaryYear(time);//获取当前日期的年份
            //获取公历日期的生肖年份
            string Tree = TreeYear.Substring(calendar.GetTerrestrialBranch(sexagenaryYear) - 1, 1);
            return Tree;//返回公历日期的生肖年份
        }

        private string GetDay(DateTime time)
        {
            //返回当前日期的农历天数
            return ChineseDayName[calendar.GetDayOfMonth(time) - 1];
        }

        private string GetMonth(DateTime time)
        {
            
            int month = calendar.GetMonth(time);//获取当前日期的月份
            int year = calendar.GetYear(time);//获取当前日期的年份
            int leap = 0;
            for (int i = 3; i < month; i++)//正月不可能是闰月
            {
                if (calendar.IsLeapMonth(year, i))//判断是否是闰月
                {
                    leap = i;
                    break;//一年中最多有一个闰月
                }
            }
            if (leap > 0) month--;
            //返回农历月份
            return (leap == month + 1 ? "闰" : "") + ChineseMonthName[month - 1];
        }

        private string GetStemBench(DateTime time)
        {
            int sexagenaryYear = calendar.GetSexagenaryYear(time);//获取当前日期的年份
            //将年份转换为干支纪年
            string stemBranch = CelestialStem.Substring(calendar.GetCelestialStem(sexagenaryYear) - 1, 1) + TerrestialBranch.Substring(calendar.GetTerrestrialBranch(sexagenaryYear) - 1, 1);
            return stemBranch;//返回干支纪年
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //将当前选中日期格式化为农历表示法
            string strYesr =String.Format("{0}年{1}月{2}", GetStemBench(monthCalendar1.SelectionStart), GetMonth(monthCalendar1.SelectionStart), GetDay(monthCalendar1.SelectionStart));
            //设置提示主题
            toolTip1.ToolTipTitle = monthCalendar1.SelectionStart.ToShortDateString();
            //显示选中日期的农历表示法
            toolTip1.Show(strYesr+"  "+GetReturnYear(monthCalendar1.SelectionStart)+"年",monthCalendar1,monthCalendar1.Location,5000);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
