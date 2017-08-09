using Academy.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Models
{
    public class Trainer : User, ITrainer
    {
        private IList<string> technologies;

        public Trainer(string username, IList<string> technologies) : base(username)
        {
            this.Technologies = technologies;
        }

        public IList<string> Technologies
        {
            get
            {
                return this.technologies;
            }
            set
            {
                this.technologies = value;
            }
        }

        public override string ToString()
        {
            return $"* Trainer:\n - Username: {base.Username}\n - Technologies: {string.Join("; ", this.Technologies)}";
        }
    }
}
