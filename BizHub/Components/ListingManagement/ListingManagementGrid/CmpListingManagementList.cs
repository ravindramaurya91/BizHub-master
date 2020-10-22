using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.ListingManagement.ListingManagementGrid {
    public partial class CmpListingManagementList {

        public List<ListingManagement_BuyerInfoDTO> ListingGrid = new List<ListingManagement_BuyerInfoDTO>
        {
            new ListingManagement_BuyerInfoDTO{BuyerOid = 40, BuyerName="Melissa Dodd",BuyerInfo="",BuyerEmail="mdodd@yahoo.com",BuyerDoc=1,BuyerChat=1,BuyerPhone="(201)667-9874",NDA=true,Profile=true,CIM=true,WalkThro=true,Offer=true,Status=false, AgentOid = 8, AgentName="Steven Grover",AgentPhone="(204)965-9856",AgentInfo="",AgentEmail="agent@email.com",AgentDoc=1,AgentChat=1},
            new ListingManagement_BuyerInfoDTO{BuyerOid = 45, BuyerName="Diana Carson",BuyerInfo="",BuyerEmail="dcarson@yahoo.com",BuyerDoc=1,BuyerChat=1,BuyerPhone="(201)667-9874",NDA=true,Profile=true,CIM=true,WalkThro=true,Offer=true,Status=false, AgentOid = 8, AgentName="Steven Grover", AgentPhone="(204)965-9856",AgentInfo="",AgentEmail="agent@email.com",AgentDoc=1,AgentChat=1},
            new ListingManagement_BuyerInfoDTO{BuyerOid = 40, BuyerName="Melissa Dodd",BuyerInfo="",BuyerEmail="test@testemail.com",BuyerDoc=1,BuyerChat=1,BuyerPhone="(201)667-9874",NDA=true,Profile=true,CIM=true,WalkThro=true,Offer=true,Status=false, AgentOid = 8, AgentName="Steven Grover",AgentPhone="(204)965-9856",AgentInfo="",AgentEmail="agent@email.com",AgentDoc=1,AgentChat=1},
            new ListingManagement_BuyerInfoDTO{BuyerOid = 45, BuyerName="Diana Carson",BuyerInfo="",BuyerEmail="test@testemail.com",BuyerDoc=1,BuyerChat=1,BuyerPhone="(201)667-9874",NDA=true,Profile=true,CIM=true,WalkThro=true,Offer=true,Status=false, AgentOid = 8, AgentName="Steven Grover",AgentPhone="(204)965-9856",AgentInfo="",AgentEmail="agent@email.com",AgentDoc=1,AgentChat=1}
        };

    }
}
