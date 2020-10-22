// AUTO GENERATED - DO NOT MODIFY DIRECTLY

using Base;
using BizHub;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SqlKata;

namespace BizHub.Service
{

    public partial class AttachmentServiceBase : DefaultService<Attachment>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.Attachment.Oid, Tables.Attachment.Name.As("name"))
                .From(Tables.Attachment);
        }
    }

    public partial class AttachmentService : AttachmentServiceBase {}

    public partial class BrokerCardServiceBase : DefaultService<BrokerCard>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class BrokerCardService : BrokerCardServiceBase {}

    public partial class ConfigurationServiceBase : DefaultService<Configuration>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.Configuration.Oid, Tables.Configuration.Name.As("name"))
                .From(Tables.Configuration);
        }
    }

    public partial class ConfigurationService : ConfigurationServiceBase {}

    public partial class ContactRequestServiceBase : DefaultService<ContactRequest>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ContactRequestService : ContactRequestServiceBase {}

    public partial class EmailCampaignServiceBase : DefaultService<EmailCampaign>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.EmailCampaign.Oid, Tables.EmailCampaign.Name.As("name"))
                .From(Tables.EmailCampaign);
        }
    }

    public partial class EmailCampaignService : EmailCampaignServiceBase {}

    public partial class EmailCampaignRunServiceBase : DefaultService<EmailCampaignRun>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class EmailCampaignRunService : EmailCampaignRunServiceBase {}

    public partial class EmailRecipientDefinitionServiceBase : DefaultService<EmailRecipientDefinition>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.EmailRecipientDefinition.Oid, Tables.EmailRecipientDefinition.Name.As("name"))
                .From(Tables.EmailRecipientDefinition);
        }
    }

    public partial class EmailRecipientDefinitionService : EmailRecipientDefinitionServiceBase {}

    public partial class EmailTemplateServiceBase : DefaultService<EmailTemplate>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.EmailTemplate.Oid, Tables.EmailTemplate.Name.As("name"))
                .From(Tables.EmailTemplate);
        }
    }

    public partial class EmailTemplateService : EmailTemplateServiceBase {}

    public partial class EntityServiceBase : DefaultService<Entity>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class EntityService : EntityServiceBase {}

    public partial class Entity2EntityMap_ContactServiceBase : DefaultService<Entity2EntityMap_Contact>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class Entity2EntityMap_ContactService : Entity2EntityMap_ContactServiceBase {}

    public partial class Entity2ListingMap_ParticipantServiceBase : DefaultService<Entity2ListingMap_Participant>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class Entity2ListingMap_ParticipantService : Entity2ListingMap_ParticipantServiceBase {}

    public partial class Entity2ListingMap_StatServiceBase : DefaultService<Entity2ListingMap_Stat>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class Entity2ListingMap_StatService : Entity2ListingMap_StatServiceBase {}

    public partial class Entity2LookupMapServiceBase : DefaultService<Entity2LookupMap>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class Entity2LookupMapService : Entity2LookupMapServiceBase {}

    public partial class EntityAttributeServiceBase : DefaultService<EntityAttribute>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class EntityAttributeService : EntityAttributeServiceBase {}

    public partial class IngredientServiceBase : DefaultService<Ingredient>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.Ingredient.Oid, Tables.Ingredient.Name.As("name"))
                .From(Tables.Ingredient);
        }
    }

    public partial class IngredientService : IngredientServiceBase {}

    public partial class InterfaceHostServiceBase : DefaultService<InterfaceHost>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.InterfaceHost.Oid, Tables.InterfaceHost.Name.As("name"))
                .From(Tables.InterfaceHost);
        }
    }

    public partial class InterfaceHostService : InterfaceHostServiceBase {}

    public partial class InterfaceIdentityMapServiceBase : DefaultService<InterfaceIdentityMap>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class InterfaceIdentityMapService : InterfaceIdentityMapServiceBase {}

    public partial class ListingServiceBase : DefaultService<Listing>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ListingService : ListingServiceBase {}

    public partial class Listing2BizCategoryMapServiceBase : DefaultService<Listing2BizCategoryMap>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class Listing2BizCategoryMapService : Listing2BizCategoryMapServiceBase {}

    public partial class ListingAttributeServiceBase : DefaultService<ListingAttribute>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.ListingAttribute.Oid, Tables.ListingAttribute.Value.As("name"))
                .From(Tables.ListingAttribute);
        }
    }

    public partial class ListingAttributeService : ListingAttributeServiceBase {}

    public partial class ListingStatServiceBase : DefaultService<ListingStat>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ListingStatService : ListingStatServiceBase {}

    public partial class LoginServiceBase : DefaultService<Login>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class LoginService : LoginServiceBase {}

    public partial class LookupServiceBase : DefaultService<Lookup>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.Lookup.Oid, Tables.Lookup.Value.As("name"))
                .From(Tables.Lookup);
        }
    }

    public partial class LookupService : LookupServiceBase {}

    public partial class LookupDefinitionServiceBase : DefaultService<LookupDefinition>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.LookupDefinition.Oid, Tables.LookupDefinition.Description.As("name"))
                .From(Tables.LookupDefinition);
        }
    }

    public partial class LookupDefinitionService : LookupDefinitionServiceBase {}

    public partial class NotificationServiceBase : DefaultService<Notification>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class NotificationService : NotificationServiceBase {}

    public partial class ProcessServiceBase : DefaultService<Process>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ProcessService : ProcessServiceBase {}

    public partial class ProcessDescriptionServiceBase : DefaultService<ProcessDescription>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.ProcessDescription.Oid, Tables.ProcessDescription.Name.As("name"))
                .From(Tables.ProcessDescription);
        }
    }

    public partial class ProcessDescriptionService : ProcessDescriptionServiceBase {}

    public partial class ProcessSequenceMapServiceBase : DefaultService<ProcessSequenceMap>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ProcessSequenceMapService : ProcessSequenceMapServiceBase {}

    public partial class ProcessStepServiceBase : DefaultService<ProcessStep>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.ProcessStep.Oid, Tables.ProcessStep.Name.As("name"))
                .From(Tables.ProcessStep);
        }
    }

    public partial class ProcessStepService : ProcessStepServiceBase {}

    public partial class RecipeServiceBase : DefaultService<Recipe>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.Recipe.Oid, Tables.Recipe.Name.As("name"))
                .From(Tables.Recipe);
        }
    }

    public partial class RecipeService : RecipeServiceBase {}

    public partial class SearchCriteriaServiceBase : DefaultService<SearchCriteria>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.SearchCriteria.Oid, Tables.SearchCriteria.Name.As("name"))
                .From(Tables.SearchCriteria);
        }
    }

    public partial class SearchCriteriaService : SearchCriteriaServiceBase {}

    public partial class SecurityGroupServiceBase : DefaultService<SecurityGroup>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.SecurityGroup.Oid, Tables.SecurityGroup.Name.As("name"))
                .From(Tables.SecurityGroup);
        }
    }

    public partial class SecurityGroupService : SecurityGroupServiceBase {}

    public partial class SecurityPwdRuleServiceBase : DefaultService<SecurityPwdRule>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.SecurityPwdRule.Oid, Tables.SecurityPwdRule.Name.As("name"))
                .From(Tables.SecurityPwdRule);
        }
    }

    public partial class SecurityPwdRuleService : SecurityPwdRuleServiceBase {}

    public partial class SequenceItemServiceBase : DefaultService<SequenceItem>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.SequenceItem.Oid, Tables.SequenceItem.Name.As("name"))
                .From(Tables.SequenceItem);
        }
    }

    public partial class SequenceItemService : SequenceItemServiceBase {}

    public partial class TextAttachmentServiceBase : DefaultService<TextAttachment>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class TextAttachmentService : TextAttachmentServiceBase {}

    public partial class TextChannelServiceBase : DefaultService<TextChannel>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.TextChannel.Oid, Tables.TextChannel.Name.As("name"))
                .From(Tables.TextChannel);
        }
    }

    public partial class TextChannelService : TextChannelServiceBase {}

    public partial class TextGroupServiceBase : DefaultService<TextGroup>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.TextGroup.Oid, Tables.TextGroup.Name.As("name"))
                .From(Tables.TextGroup);
        }
    }

    public partial class TextGroupService : TextGroupServiceBase {}

    public partial class TextInvitationServiceBase : DefaultService<TextInvitation>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class TextInvitationService : TextInvitationServiceBase {}

    public partial class TextMessageServiceBase : DefaultService<TextMessage>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class TextMessageService : TextMessageServiceBase {}

    public partial class TextMessageActionServiceBase : DefaultService<TextMessageAction>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class TextMessageActionService : TextMessageActionServiceBase {}

    public partial class TextRecipientServiceBase : DefaultService<TextRecipient>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class TextRecipientService : TextRecipientServiceBase {}

    public partial class Whse_ListingStatServiceBase : DefaultService<Whse_ListingStat>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class Whse_ListingStatService : Whse_ListingStatServiceBase {}

    public partial class Whse_RunSearchArchiveServiceBase : DefaultService<Whse_RunSearchArchive>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
        public override Query CreateLookupQuery()
        {
            return Database.CreateQuery()
                .Select(Tables.Whse_RunSearchArchive.Oid, Tables.Whse_RunSearchArchive.Name.As("name"))
                .From(Tables.Whse_RunSearchArchive);
        }
    }

    public partial class Whse_RunSearchArchiveService : Whse_RunSearchArchiveServiceBase {}

    public partial class ZCServiceBase : DefaultService<ZC>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ZCService : ZCServiceBase {}

    public partial class ZC_MultiCountyServiceBase : DefaultService<ZC_MultiCounty>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ZC_MultiCountyService : ZC_MultiCountyServiceBase {}

    public partial class ZC_PlaceFIPSServiceBase : DefaultService<ZC_PlaceFIPS>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ZC_PlaceFIPSService : ZC_PlaceFIPSServiceBase {}

    public partial class ZipCodeServiceBase : DefaultService<ZipCode>
    {
        public override Query CreateResultQuery() 
        {
            Query query = CreateDefaultQuery();
            return query;
        }
    }

    public partial class ZipCodeService : ZipCodeServiceBase {}

}
