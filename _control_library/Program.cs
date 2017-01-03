using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _control_library
{
    
    abstract class _abstract_library
    {
        protected string name;

        public _abstract_library(string name)
        {
            this.name = name;
        }
        public abstract void _add(_abstract_library _control);
        public abstract void _remove(_abstract_library _control);
        public abstract void _show(int i);
    }
    class _mix_control : _abstract_library
    {

        private List<_abstract_library> _unit_list = new List<_abstract_library>();
        public _mix_control(string name)
            : base(name)
        { }
        public override void _add(_abstract_library _control)
        {
            _unit_list.Add(_control);
        }
        public override void _remove(_abstract_library _control)
        {
            _unit_list.Remove(_control);
        }
        
        public override void _show(int i)
        {
            Console.WriteLine(new String(' ', i) + name);
            foreach (_abstract_library _al in _unit_list)
            {
                _al._show(i + 2);
            }
        }

    }
    class _unit_control : _abstract_library
    {
        public _unit_control(string name)
            : base(name)
        { }
        public override void _add(_abstract_library _control)
        {
            Console.WriteLine("对不起，不支持添加");

        }
        public override void _remove(_abstract_library _control)
        {
            Console.WriteLine("对不起，不支持删除");
        }
        public override void _show(int i)
        {
            Console.WriteLine(new String(' ', i) + name);

        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            _mix_control _unit = new _mix_control("单元控件：");
            _unit._add(new _unit_control("Label标签"));
            _unit._add(new _unit_control("TextField输入文本框"));

            _mix_control _mix = new _mix_control("容器控件");

            _unit._add(_mix);

            _mix_control _mix1 = new _mix_control("GroupBox组框");
            _mix1._add(new _unit_control("容器控件"));

            _mix._add(_mix1);

            _mix_control _mix2 = new _mix_control("单元控件");
            _mix2._add(new _unit_control("Label标签"));
            _mix2._add(new _unit_control("TextField输入文本框"));
            _mix2._add(new _unit_control("Button按钮"));
            _mix1._add(_mix2);
            _unit._add(new _unit_control("Button按钮"));
            _unit._add(new _unit_control("其他控件"));

            _unit._show(0);


            Console.Read();
        }

    }
   
}
