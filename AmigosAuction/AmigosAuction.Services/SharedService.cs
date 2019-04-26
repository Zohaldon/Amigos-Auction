using AmigosAuction.Data;
using AmigosAuction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosAuction.Services
{
    public class SharedService
    {
        AmigosAuctionContext context;

        public int SavePicture(Picture picture)
        {
            context = new AmigosAuctionContext();
            //Need to add EnityFramework from NuggetPackageManager
            context.Pictures.Add(picture);
            context.SaveChanges();
            return picture.ID;
        }

        public bool LeaveComment(Comment comment)
        {
            context = new AmigosAuctionContext();
            //Need to add EnityFramework from NuggetPackageManager
            context.Comments.Add(comment);
            return context.SaveChanges() > 0;
            
        }

        public List<Comment> GetComments(int entityID, int recordID)
        {
            context = new AmigosAuctionContext();
            return context.Comments.Where(x => x.EntityID == entityID && x.RecordID == recordID).ToList();
        }
    }
}
