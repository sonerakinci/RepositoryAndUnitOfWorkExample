using Msdn.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA.RepositoryAndUnitOfWorkExample.Base;

namespace WFA.RepositoryAndUnitOfWorkExample
{
    public partial class frmTest : BaseForm
    {
        public frmTest()
        {
            InitializeComponent();
            GetSubscribers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddSubscriber();
            GetSubscribers();
        }

        bool AddSubscriber()
        {
            var subscriber = new Subscriber
            {
                SubscriberId = Guid.NewGuid(),
                FullName = txtFullName.Text,
                RegisterationDate = DateTime.Now,
                IsActive = chcIsActive.Checked
            };

            var address = new Address
            {
                SubscriberId = subscriber.SubscriberId,
                Detail = txtAddress.Text,
                Subscriber = subscriber
            };

            Worker.Subscribers.ChangeEntityState(subscriber, EntityState.Added);
            Worker.Address.ChangeEntityState(address, EntityState.Added);

            return Worker.SaveChanges()>0;
        }

        void GetSubscribers()
        {
            dgSubscribers.DataSource = null;
            dgSubscribers.DataSource = Worker.Subscribers.Select(s => new {FullName=s.FullName,Address=s.Address.Detail,IsActivated=s.IsActive }).ToList();
        }
    }
}
