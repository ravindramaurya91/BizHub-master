// AUTO GENERATED - DO NOT MODIFY DIRECTLY

using Base;
using Model;
using BizHub.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BizHub
{

    public class StartupBase : IStartupBase
    {
        public void AddLookupProviders(IServiceCollection services)
        {
            services.AddTransient<ILookupProvider<Attachment>, AttachmentService>();
            services.AddTransient<ILookupProvider<BrokerCard>, BrokerCardService>();
            services.AddTransient<ILookupProvider<Configuration>, ConfigurationService>();
            services.AddTransient<ILookupProvider<ContactRequest>, ContactRequestService>();
            services.AddTransient<ILookupProvider<EmailCampaign>, EmailCampaignService>();
            services.AddTransient<ILookupProvider<EmailCampaignRun>, EmailCampaignRunService>();
            services.AddTransient<ILookupProvider<EmailRecipientDefinition>, EmailRecipientDefinitionService>();
            services.AddTransient<ILookupProvider<EmailTemplate>, EmailTemplateService>();
            services.AddTransient<ILookupProvider<Entity>, EntityService>();
            services.AddTransient<ILookupProvider<Entity2EntityMap_Contact>, Entity2EntityMap_ContactService>();
            services.AddTransient<ILookupProvider<Entity2ListingMap_Participant>, Entity2ListingMap_ParticipantService>();
            services.AddTransient<ILookupProvider<Entity2ListingMap_Stat>, Entity2ListingMap_StatService>();
            services.AddTransient<ILookupProvider<Entity2LookupMap>, Entity2LookupMapService>();
            services.AddTransient<ILookupProvider<EntityAttribute>, EntityAttributeService>();
            services.AddTransient<ILookupProvider<Ingredient>, IngredientService>();
            services.AddTransient<ILookupProvider<InterfaceHost>, InterfaceHostService>();
            services.AddTransient<ILookupProvider<InterfaceIdentityMap>, InterfaceIdentityMapService>();
            services.AddTransient<ILookupProvider<Listing>, ListingService>();
            services.AddTransient<ILookupProvider<Listing2BizCategoryMap>, Listing2BizCategoryMapService>();
            services.AddTransient<ILookupProvider<ListingAttribute>, ListingAttributeService>();
            services.AddTransient<ILookupProvider<ListingStat>, ListingStatService>();
            services.AddTransient<ILookupProvider<Login>, LoginService>();
            services.AddTransient<ILookupProvider<Lookup>, LookupService>();
            services.AddTransient<ILookupProvider<LookupDefinition>, LookupDefinitionService>();
            services.AddTransient<ILookupProvider<Notification>, NotificationService>();
            services.AddTransient<ILookupProvider<Process>, ProcessService>();
            services.AddTransient<ILookupProvider<ProcessDescription>, ProcessDescriptionService>();
            services.AddTransient<ILookupProvider<ProcessSequenceMap>, ProcessSequenceMapService>();
            services.AddTransient<ILookupProvider<ProcessStep>, ProcessStepService>();
            services.AddTransient<ILookupProvider<Recipe>, RecipeService>();
            services.AddTransient<ILookupProvider<SearchCriteria>, SearchCriteriaService>();
            services.AddTransient<ILookupProvider<SecurityGroup>, SecurityGroupService>();
            services.AddTransient<ILookupProvider<SecurityPwdRule>, SecurityPwdRuleService>();
            services.AddTransient<ILookupProvider<SequenceItem>, SequenceItemService>();
            services.AddTransient<ILookupProvider<TextAttachment>, TextAttachmentService>();
            services.AddTransient<ILookupProvider<TextChannel>, TextChannelService>();
            services.AddTransient<ILookupProvider<TextGroup>, TextGroupService>();
            services.AddTransient<ILookupProvider<TextInvitation>, TextInvitationService>();
            services.AddTransient<ILookupProvider<TextMessage>, TextMessageService>();
            services.AddTransient<ILookupProvider<TextMessageAction>, TextMessageActionService>();
            services.AddTransient<ILookupProvider<TextRecipient>, TextRecipientService>();
            services.AddTransient<ILookupProvider<Whse_ListingStat>, Whse_ListingStatService>();
            services.AddTransient<ILookupProvider<Whse_RunSearchArchive>, Whse_RunSearchArchiveService>();
            services.AddTransient<ILookupProvider<ZC>, ZCService>();
            services.AddTransient<ILookupProvider<ZC_MultiCounty>, ZC_MultiCountyService>();
            services.AddTransient<ILookupProvider<ZC_PlaceFIPS>, ZC_PlaceFIPSService>();
            services.AddTransient<ILookupProvider<ZipCode>, ZipCodeService>();
        }
        public void AddMetadataTables(IServiceCollection services)
        {
            services.AddTransient<IMetadata<Attachment>, AttachmentMetadata>();
            services.AddTransient<IMetadata<BrokerCard>, BrokerCardMetadata>();
            services.AddTransient<IMetadata<Configuration>, ConfigurationMetadata>();
            services.AddTransient<IMetadata<ContactRequest>, ContactRequestMetadata>();
            services.AddTransient<IMetadata<EmailCampaign>, EmailCampaignMetadata>();
            services.AddTransient<IMetadata<EmailCampaignRun>, EmailCampaignRunMetadata>();
            services.AddTransient<IMetadata<EmailRecipientDefinition>, EmailRecipientDefinitionMetadata>();
            services.AddTransient<IMetadata<EmailTemplate>, EmailTemplateMetadata>();
            services.AddTransient<IMetadata<Entity>, EntityMetadata>();
            services.AddTransient<IMetadata<Entity2EntityMap_Contact>, Entity2EntityMap_ContactMetadata>();
            services.AddTransient<IMetadata<Entity2ListingMap_Participant>, Entity2ListingMap_ParticipantMetadata>();
            services.AddTransient<IMetadata<Entity2ListingMap_Stat>, Entity2ListingMap_StatMetadata>();
            services.AddTransient<IMetadata<Entity2LookupMap>, Entity2LookupMapMetadata>();
            services.AddTransient<IMetadata<EntityAttribute>, EntityAttributeMetadata>();
            services.AddTransient<IMetadata<Ingredient>, IngredientMetadata>();
            services.AddTransient<IMetadata<InterfaceHost>, InterfaceHostMetadata>();
            services.AddTransient<IMetadata<InterfaceIdentityMap>, InterfaceIdentityMapMetadata>();
            services.AddTransient<IMetadata<Listing>, ListingMetadata>();
            services.AddTransient<IMetadata<Listing2BizCategoryMap>, Listing2BizCategoryMapMetadata>();
            services.AddTransient<IMetadata<ListingAttribute>, ListingAttributeMetadata>();
            services.AddTransient<IMetadata<ListingStat>, ListingStatMetadata>();
            services.AddTransient<IMetadata<Login>, LoginMetadata>();
            services.AddTransient<IMetadata<Lookup>, LookupMetadata>();
            services.AddTransient<IMetadata<LookupDefinition>, LookupDefinitionMetadata>();
            services.AddTransient<IMetadata<Notification>, NotificationMetadata>();
            services.AddTransient<IMetadata<Process>, ProcessMetadata>();
            services.AddTransient<IMetadata<ProcessDescription>, ProcessDescriptionMetadata>();
            services.AddTransient<IMetadata<ProcessSequenceMap>, ProcessSequenceMapMetadata>();
            services.AddTransient<IMetadata<ProcessStep>, ProcessStepMetadata>();
            services.AddTransient<IMetadata<Recipe>, RecipeMetadata>();
            services.AddTransient<IMetadata<SearchCriteria>, SearchCriteriaMetadata>();
            services.AddTransient<IMetadata<SecurityGroup>, SecurityGroupMetadata>();
            services.AddTransient<IMetadata<SecurityPwdRule>, SecurityPwdRuleMetadata>();
            services.AddTransient<IMetadata<SequenceItem>, SequenceItemMetadata>();
            services.AddTransient<IMetadata<TextAttachment>, TextAttachmentMetadata>();
            services.AddTransient<IMetadata<TextChannel>, TextChannelMetadata>();
            services.AddTransient<IMetadata<TextGroup>, TextGroupMetadata>();
            services.AddTransient<IMetadata<TextInvitation>, TextInvitationMetadata>();
            services.AddTransient<IMetadata<TextMessage>, TextMessageMetadata>();
            services.AddTransient<IMetadata<TextMessageAction>, TextMessageActionMetadata>();
            services.AddTransient<IMetadata<TextRecipient>, TextRecipientMetadata>();
            services.AddTransient<IMetadata<Whse_ListingStat>, Whse_ListingStatMetadata>();
            services.AddTransient<IMetadata<Whse_RunSearchArchive>, Whse_RunSearchArchiveMetadata>();
            services.AddTransient<IMetadata<ZC>, ZCMetadata>();
            services.AddTransient<IMetadata<ZC_MultiCounty>, ZC_MultiCountyMetadata>();
            services.AddTransient<IMetadata<ZC_PlaceFIPS>, ZC_PlaceFIPSMetadata>();
            services.AddTransient<IMetadata<ZipCode>, ZipCodeMetadata>();
        }
    }

}
