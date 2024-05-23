using Microsoft.EntityFrameworkCore;
using SLM.User.Domain.Entities.Models;
using SLM.User.Infrastructure.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.Extensions
{
    public static class InitialDataSeeder
    {
        //public static void seed(this modelbuilder modelbuilder)
        //{
        //    // user type 
        //    var userid = Guid.NewGuid();
        //    var designationid = Guid.newguid();
        //    var usertypeid = Guid.newguid();

        //    modelbuilder.entity<usertypeentity>().hasdata(
        //        new usertypeentity
        //        {
        //            entityid = usertypeid,
        //            typename = "adminstrator",
        //            description = "this user will be having access to all and will also create the users",
        //            createdat = datetime.utcnow,
        //            createdby = guid.empty,
        //            updatedat = datetime.utcnow,
        //            updatedby = guid.empty,
        //            isdeleted = 0
        //        });

        //    modelbuilder.entity<emailtemplatesentity>().hasdata(
        //        new emailtemplatesentity
        //        {
        //            entityid = designationid,
        //            title = "super-admin",
        //            description = "this is a super admin designation and will be only one user",
        //            createdat = datetime.utcnow,
        //            createdby = guid.empty,
        //            updatedat = datetime.utcnow,
        //            updatedby = guid.empty,
        //            isdeleted = 0
        //        });



        //    modelbuilder.entity<userentity>().hasdata(
        //        new userentity
        //        {
        //            entityid = userid,
        //            firstname = "super",
        //            middlename = "sa",
        //            lastname = "administrator",
        //            dateofbirth = datetime.utcnow,
        //            designationid = designationid,
        //            usertypeid = usertypeid,
        //            country = "india",
        //            state = "karnataka",
        //            email = "devkranth@gmail.com",
        //            phonenumber = "9999999999",
        //            postalcode = "999999",
        //            createdat = datetime.utcnow,
        //            createdby = guid.empty,
        //            updatedat = datetime.utcnow,
        //            updatedby = guid.empty,
        //            isdeleted = 0
        //        }
        //    );
        //    modelbuilder.entity<usercredentialentity>().hasdata(
        //       new usercredentialentity
        //       {
        //           entityid = guid.newguid(),
        //           userid = userid,
        //           username = "adminstrator",
        //           hashedpassword = passwordhasher.hashpassword("adminstrator"),
        //           dtpasswordchanged = datetime.utcnow,
        //           passwordchanged = 1,
        //           createdat = datetime.utcnow,
        //           createdby = guid.empty,
        //           updatedat = datetime.utcnow,
        //           updatedby = guid.empty,
        //           isdeleted = 0
        //       }
        //   );
        //}

    }
}
