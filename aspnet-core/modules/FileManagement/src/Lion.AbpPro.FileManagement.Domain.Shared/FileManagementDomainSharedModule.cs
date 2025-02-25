using Lion.AbpPro.Core;

namespace Lion.AbpPro.FileManagement;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpProCoreModule)
)]
public class FileManagementDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<FileManagementDomainSharedModule>(); });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<FileManagementResource>(FileManagementConsts.DefaultCultureName)
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/FileManagement");
        });

        Configure<AbpExceptionLocalizationOptions>(options => { options.MapCodeNamespace(FileManagementConsts.NameSpace, typeof(FileManagementResource)); });
    }
}