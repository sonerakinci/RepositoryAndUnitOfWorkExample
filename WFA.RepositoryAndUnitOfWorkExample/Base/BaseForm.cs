using Msdn.DataAccess.Base;
using Msdn.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA.RepositoryAndUnitOfWorkExample.Base
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private Worker _worker;
        protected Worker Worker
        {
            get
            {
                return _worker ?? (_worker = new Worker(new DbMsdn()));
            }
            private set
            {
                _worker = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && Worker != null)
            {
                Worker.Dispose();
                Worker = null;
            }
        }
    }
}
