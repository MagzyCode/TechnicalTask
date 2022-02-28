using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Net;

namespace ServerPart.Models.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            using var webClient = new WebClient();
            builder.HasData(
                new Products()
                {
                    Id = new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), 
                    Name = "Pepper",
                    DefaultQuantity = 1,
                    Image = webClient.DownloadData("https://avatars.mds.yandex.net/get-zen_doc/1708203/pub_5e98b4d479955f4a2e8fa8d5_5e998982d836344f31c777e7/scale_1200")
                },
                new Products()
                {
                    Id = new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), 
                    Name = "Milk",
                    DefaultQuantity = 2,
                    Image = webClient.DownloadData("https://yandex-images.clstorage.net/P4ui72U40/091178XZDh/fe5vn1LH-txadKIvY9UuzJA8isABg081y1OqTGaDWc5ObnoTYs-gVT9XuPAtRn-yiWEM5Rtms8YHCFsC7gPRpjr4Y4RNnu_YHnDiOhKOeoqJcdudBt4EKZcCvVY2gE_RATwnfGKPsBlvDeuXLER2raZLL_tvCcmjfSoqdK5UivFo5XvSBPnTnXt8gCkL3gnv6gaewSqhcFPGdbsvUrBuq1xqQQ5Ewo4yWjHPpkwVK9SSWyrffi7PhlwHDmyhf6P4Y9Y25BXA7fpPXpwZD-Eb6e8njsgRl3B96XekLE28Q7VFWX0eVO6zN38KyJtVHzHErEU4-VU45Zl3Ow90gWyn_GXXBdM2ytn2aWSmMAHXJPTVIJHAIoVkWel9iRpOrnqhUWxVGEXyjS9MBP-ESCAg9ptOG_9hNc-dVzU0X5pNvu9E9iD8Nd_D9UdhuC4V_B_vxwai1AKQY2j9dLQmT757pFtZRT9N55Y0Qy_Womk6AfO0ZzjRXRjWsnsfEnCeUJb8es8h2TLLxOVce505Kss4zssXp8MivHFi4E-NKHe1YahuZkEVa-SMD08lwKpbNQXVkVML9XUC3J5-AxVNuEOo03v_BegRzOP5fGKWPzvdBfvVHaX7Mo1xU8Z_hwdVsn6xR01mO27Lsz9-NvS9SCU88IBMKu1mAOOcRQ4iSJpDrfxkzjjWLePe82hMnDsA4AHF0ACm7TOPXkHfRLkqeIhLiHJlUh9izqo-dwzEuU0zN8ufcgr-eyHVuFYjDm-1faXfSegd-A7tw-1ibZwYD8gg_O8_uOIBqnNV6ky8O0WLX5FZXnYBS9GOOHcC4JFFADfXimYE2GE145pYBjZYvleP_2zYJvE67eXkXWyKKC7tGfDbH6zhIKlVf-F-mDBip1uEQEFOLk7ltilFDtiMWzA11KltOf1gA9GGZQEaXrF9rtxCyx7lJNfCzG1_pzIH0x_4_Q6C3x-veFjrV44BbZc")
                },
                new Products()
                {
                    Id = new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), 
                    Name = "Wine",
                    DefaultQuantity = 1,
                    Image = webClient.DownloadData("https://zviazda.by/sites/default/files/58_original.jpg")
                },
                new Products()
                {
                    Id = new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), 
                    Name = "Curd",
                    DefaultQuantity = 2,
                    Image = webClient.DownloadData("https://domstrousam.ru/wp-content/uploads/2021/04/tvorog_kisliy.jpg")
                },
                new Products()
                {
                    Id = new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), 
                    Name = "Tomato",
                    DefaultQuantity = 10,
                    Image = webClient.DownloadData("https://avatars.mds.yandex.net/get-zen_doc/59126/pub_60fbee8a51197c3f21755b6f_60fbeee6b58324630f3e9a57/scale_1200")
                },
                new Products()
                {
                    Id = new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), 
                    Name = "Сarrot",
                    DefaultQuantity = 4,
                    Image = webClient.DownloadData("https://stroy-podskazka.ru/images/article/orig/2021/09/vse-chto-nuzhno-znat-o-morkovi.jpg")
                }
            );
        }
    }
}
