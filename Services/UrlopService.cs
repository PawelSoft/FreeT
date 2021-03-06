using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using FreeT.DTO;
using FreeT.Repositories;
using System;

namespace FreeT.Services
{
    public class UrlopService : IUrlopService
    {
        IConfiguration configuration;
        IUrlopRepository urlopyRepository;
        public UrlopService(IConfiguration configuration, IUrlopRepository urlopyRepository)
        {
            this.configuration = configuration;
            this.urlopyRepository = urlopyRepository;
        }

        public bool Create(UrlopAddDTO dto)
        {
            if (urlopyRepository.SprawdzIloscDni(dto.Data_Do, dto.Data_Od))
            {
                return urlopyRepository.Create(dto);
            }
            else
            {
                return false;
            }
        }

        public UrlopDTO Get(long Uzytkownik_Id)
        {
           return urlopyRepository.Get(Uzytkownik_Id);
        }

        public UrlopDTO GetFromData(long Uzytkownik_Id, DateTime Data)
        {
           return urlopyRepository.GetFromData(Uzytkownik_Id, Data);
        }


        public IList<UrlopDTO> GetAll()
        {
            return urlopyRepository.GetAll();
        }

        public string Delete(Int64 Urlop_Id)
        {
            if (urlopyRepository.SprawdzCzyIdIstnieje(Urlop_Id))
            {
                if (urlopyRepository.Delete(Urlop_Id))
                    return null;
                else
                    return "nie udało się usunąć";
            }
            else
            {
                return "obiekt nie istnieje";
            }
        }
    }
}