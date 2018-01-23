using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class MissingMapper
    {

        public static Missing MissingModelToMissing(MissingModel model)
        {
            var missing = new Missing
            {
                Id = model.Id,
                OfficeId = model.OfficeId,
                UserId = model.UserId,

                FiscalYearId = model.FiscalYearId,
                RegistrationNumber = model.RegistrationNumber,

                VerifyUserId = model.VerifyUserId,
                VerifyStatus = model.VerifyStatus,
                verifydate = model.verifydate,
                VerifyMessage = model.VerifyMessage,
                EnteredDate = model.EnteredDate,

                Fname= model.Fname,
                Lname = model.Lname,
                Alias = model.Alias,

                MaritialStatus = model.MaritialStatus,
                EthnicityId = model.EthnicityId,
                Gender = model.Gender,
                PersonType = model.PersonType,

                FatherName = model.FatherName,
                MotherName = model.MotherName,
                SpouseName = model.SpouseName,
                
                NationalityId = model.NationalityId,
                SpecialIdentifier = model.SpecialIdentifier,
                IdTypeId = model.IdTypeId,
                IdTypeNumber = model.IdTypeNumber,
                ReligionId = model.ReligionId,
                Occupation = model.Occupation,
                EducationLevelId = model.EducationLevelId,

                DOB = model.DOB,
                EstimatedAge = model.EstimatedAge,
                Hieght = model.Hieght,
                Weight = model.Weight,
                HeightUnit=model.HeightUnit,

                ClothesWorn = model.ClothesWorn,
                EyeColorId = model.EyeColorId,
                HairColorId = model.HairColorId,
                Build = model.Build,
                Language = model.Language,

                TStateId = model.TStateId,
                TDistrictId = model.TDistrictId,
                TMunicipalityId = model.TMunicipalityId,
                TWardNumber = model.TWardNumber,
                TToleName = model.TToleName,
                TContactNumber = model.TContactNumber,

                PStateId=model.PStateId,
                PDistrictId=model.PDistrictId,
                PMunicipalityId=model.PMunicipalityId,
                PWardNumber=model.PWardNumber,
                PContactNumber=model.PContactNumber,
                PToleName=model.PToleName,

                LastSeenDate = model.LastSeenDate,
                LastSeenTime = model.LastSeenTime,
                LastSeenPlace = model.LastSeenPlace,

                MStateId=model.MStateId,
                MDistrictId = model.MDistrictId,
                MMunicipalityId=model.MMunicipalityId,
                MWardNumber=model.MWardNumber,
                MToleName=model.MToleName,

                ComplainByName = model.ComplainByName,
                ComplainDate = model.ComplainDate,
                ComplainContactNumber = model.ComplainContactNumber,
                Remarks = model.Remarks,

                Photo= model.Photo,
                PossiblePlaces =model.PossiblePlaces,
                MissingStatus = model.MissingStatus,

                DateOfFound = model.DateOfFound,
                FoundAddress = model.FoundAddress,
                LiveStatus = model.LiveStatus,

                FoundRemarks = model.FoundRemarks,
                FoundByOfficeId = model.FoundByOfficeId,
                LastSearchActivityDate = model.LastSearchActivityDate,
                RelationWithVictim = model.RelationWithVictim,
                MissingReason = model.MissingReason,
                HandOverTo = model.HandOverTo,
                HandOverDetails = model.HandOverDetails,
                HandOverDate = model.HandOverDate,
                HandOverRelation = model.HandOverRelation,
                HandOverContactNumber = model.HandOverContactNumber


            };

            return missing;
        }

        public static MissingModel MissingToMissingModel(Missing model)
        {

            var missingModel = new MissingModel
            {

                Id = model.Id,
                OfficeId = model.OfficeId,
                UserId = model.UserId,
                User = new UserModel
                {
                    Username = model.User != null ? model.User.Username : ""
                },

                FiscalYearId = model.FiscalYearId,
                RegistrationNumber = model.RegistrationNumber,

                VerifyUserId = model.VerifyUserId,
                VerifyStatus = model.VerifyStatus,
                verifydate = model.verifydate,
                VerifyMessage = model.VerifyMessage,
                EnteredDate = model.EnteredDate,

                Fname = model.Fname,
                Lname = model.Lname,
                Alias = model.Alias,

                MaritialStatus = model.MaritialStatus,
                EthnicityId = model.EthnicityId,
                Gender = model.Gender,
                PersonType = model.PersonType,

                FatherName = model.FatherName,
                MotherName = model.MotherName,
                SpouseName = model.SpouseName,

                NationalityId = model.NationalityId,
                SpecialIdentifier = model.SpecialIdentifier,
                IdTypeId = model.IdTypeId,
                IdTypeNumber = model.IdTypeNumber,
                ReligionId = model.ReligionId,
                Occupation = model.Occupation,
                EducationLevelId = model.EducationLevelId,

                DOB = model.DOB,
                EstimatedAge = model.EstimatedAge,
                Hieght = model.Hieght,
                Weight = model.Weight,
                HeightUnit=model.HeightUnit,

                ClothesWorn = model.ClothesWorn,
                EyeColorId = model.EyeColorId,
                HairColorId = model.HairColorId,
                Build = model.Build,
                Language = model.Language,
                Hair = model.Hair,
                TStateId = model.TStateId,
                TDistrictId = model.TDistrictId,
                TMunicipalityId = model.TMunicipalityId,
                TWardNumber = model.TWardNumber,
                TToleName = model.TToleName,
                TContactNumber = model.TContactNumber,

                PStateId = model.PStateId,
                PDistrictId = model.PDistrictId,
                PMunicipalityId = model.PMunicipalityId,
                PWardNumber = model.PWardNumber,
                PContactNumber = model.PContactNumber,
                PToleName = model.PToleName,

                LastSeenDate = model.LastSeenDate,
                LastSeenTime = model.LastSeenTime,
                LastSeenPlace = model.LastSeenPlace,

                MStateId = model.MStateId,
                MDistrictId = model.MDistrictId,
                MMunicipalityId = model.MMunicipalityId,
                MWardNumber = model.MWardNumber,
                MToleName = model.MToleName,

                ComplainByName = model.ComplainByName,
                ComplainDate = model.ComplainDate,
                ComplainContactNumber = model.ComplainContactNumber,
                Remarks = model.Remarks,

                Photo = model.Photo,
                PossiblePlaces = model.PossiblePlaces,
                MissingStatus = model.MissingStatus,

                DateOfFound = model.DateOfFound,
                FoundAddress = model.FoundAddress,
                LiveStatus = model.LiveStatus,
                FoundRemarks = model.FoundRemarks,
                FoundByOfficeId = model.FoundByOfficeId,
                LastSearchActivityDate = model.LastSearchActivityDate,
                RelationWithVictim = model.RelationWithVictim,
                MissingReason = model.MissingReason,
                HandOverTo = model.HandOverTo,
                HandOverDetails = model.HandOverDetails,
                HandOverDate = model.HandOverDate,
                HandOverRelation = model.HandOverRelation,
                HandOverContactNumber = model.HandOverContactNumber,
                Ethnicity = new EthnicityModel
                {
                    EthnicityName = model.Ethnicity != null ? model.Ethnicity.EthnicityName : ""
                },
                Office = new OfficeModel
                {
                    OfficeName = model.Office != null ? model.Office.OfficeName : ""
                },
                country = new CountryModel
                {
                    Id = model.country?.Id ?? 0,
                    CountryName = model.country != null ? model.country.CountryName : "",
                    CountryCode = model.country != null ? model.country.CountryCode : "",
                    Nationality = model.country != null ? model.country.Nationality : ""

                },
                Religion = new ReligionModel
                {
                    Id = model.Religion?.Id ?? 0,
                    ReligionName = model.Religion != null ? model.Religion.ReligionName : ""
                },
                EducationLevel = new EducationLevelModel
                {
                    Id = model.EducationLevel?.Id ?? 0,
                    LevelName = model.EducationLevel != null ? model.EducationLevel.LevelName : ""
                },
                Colour = new ColourModel
                {
                    id = model.Colour?.id ?? 0,
                    ColourName = model.Colour != null ? model.Colour.ColourName : "",

                },
                Municipality = new MunicipalityModel
                {
                    Id = model.Municipality?.Id ?? 0,
                    MunicipalityName = model.Municipality != null ? model.Municipality.MunicipalityName : "",
                    MuniTypeId = model.Municipality != null ? model.Municipality.MuniTypeId : 0,
                    MunType = new MuncipalityTypeModel
                    {
                        MuniType = model.Municipality != null ? model.Municipality.MunicipalityType.MuniType : "",

                    },
                    District = new DistrictModel
                    {
                        DistrictCode = model.Municipality != null ? Convert.ToInt32(model.Municipality.District?.DistrictCode) : 0,
                        DistrictNameEng = model.Municipality != null ? model.Municipality.District.DistrictNameEng : "",
                        State = new StateModel
                        {
                            StateName = model.Municipality != null ? model.Municipality.District.State.StateName : ""
                        }
                    }
                }









            };

           
            return missingModel;
        }

        public static List<MissingModel> MissingListToMissingModelList(List<Missing> models)
        {
            var missingModelList = new List<MissingModel>();

            foreach (var model in models)
            {
                missingModelList.Add(new MissingModel
                {

                    Id = model.Id,
                    OfficeId = model.OfficeId,
                    UserId = model.UserId,
                    User = new UserModel
                    {
                        Username = model.User != null ? model.User.Username : ""
                    },

                    FiscalYearId = model.FiscalYearId,
                    RegistrationNumber = model.RegistrationNumber,

                    VerifyUserId = model.VerifyUserId,
                    VerifyStatus = model.VerifyStatus,
                    verifydate = model.verifydate,
                    VerifyMessage = model.VerifyMessage,
                    EnteredDate = model.EnteredDate,

                    Fname = model.Fname,
                    Lname = model.Lname,
                    Alias = model.Alias,

                    MaritialStatus = model.MaritialStatus,
                    EthnicityId = model.EthnicityId,
                    Gender = model.Gender,
                    PersonType = model.PersonType,

                    FatherName = model.FatherName,
                    MotherName = model.MotherName,
                    SpouseName = model.SpouseName,

                    NationalityId = model.NationalityId,
                    SpecialIdentifier = model.SpecialIdentifier,
                    IdTypeId = model.IdTypeId,
                    IdTypeNumber = model.IdTypeNumber,
                    ReligionId = model.ReligionId,
                    Occupation = model.Occupation,
                    EducationLevelId = model.EducationLevelId,

                    DOB = model.DOB,
                    EstimatedAge = model.EstimatedAge,
                    Hieght = model.Hieght,
                    Weight = model.Weight,
                    HeightUnit=model.HeightUnit,
                   
                    ClothesWorn = model.ClothesWorn,
                    EyeColorId = model.EyeColorId,
                    HairColorId = model.HairColorId,
                    Build = model.Build,
                    Language = model.Language,
                    Hair = model.Hair,
                    TStateId = model.TStateId,
                    TDistrictId = model.TDistrictId,
                    TMunicipalityId = model.TMunicipalityId,
                    TWardNumber = model.TWardNumber,
                    TToleName = model.TToleName,
                    TContactNumber = model.TContactNumber,

                    PStateId = model.PStateId,
                    PDistrictId = model.PDistrictId,
                    PMunicipalityId = model.PMunicipalityId,
                    PWardNumber = model.PWardNumber,
                    PContactNumber = model.PContactNumber,
                    PToleName = model.PToleName,

                    LastSeenDate = model.LastSeenDate,
                    LastSeenTime = model.LastSeenTime,
                    LastSeenPlace = model.LastSeenPlace,

                    MStateId = model.MStateId,
                    MDistrictId = model.MDistrictId,
                    MMunicipalityId = model.MMunicipalityId,
                    MWardNumber = model.MWardNumber,
                    MToleName = model.MToleName,

                    ComplainByName = model.ComplainByName,
                    ComplainDate = model.ComplainDate,
                    ComplainContactNumber = model.ComplainContactNumber,
                    Remarks = model.Remarks,

                    Photo = model.Photo,
                    PossiblePlaces = model.PossiblePlaces,
                    MissingStatus = model.MissingStatus,

                    DateOfFound = model.DateOfFound,
                    FoundAddress = model.FoundAddress,
                    LiveStatus = model.LiveStatus,
                    FoundRemarks = model.FoundRemarks,
                    FoundByOfficeId = model.FoundByOfficeId,
                    LastSearchActivityDate = model.LastSearchActivityDate,
                    RelationWithVictim = model.RelationWithVictim,
                    MissingReason = model.MissingReason,
                    HandOverTo = model.HandOverTo,
                    HandOverDetails = model.HandOverDetails,
                    HandOverDate = model.HandOverDate,
                    HandOverRelation = model.HandOverRelation,
                    HandOverContactNumber = model.HandOverContactNumber,
                    Ethnicity = new EthnicityModel
                    {
                        EthnicityName = model.Ethnicity != null ? model.Ethnicity.EthnicityName : ""
                    },
                    Office = new OfficeModel
                    {
                        OfficeName = model.Office != null ? model.Office.OfficeName : ""
                    },
                    country = new CountryModel
                    {
                        Id = model.country?.Id ?? 0,
                        CountryName = model.country != null ? model.country.CountryName : "",
                        CountryCode = model.country != null ? model.country.CountryCode : "",
                        Nationality = model.country != null ? model.country.Nationality : ""

                    },
                    Religion = new ReligionModel
                    {
                        Id = model.Religion?.Id ?? 0,
                        ReligionName = model.Religion != null ? model.Religion.ReligionName : ""
                    },
                    EducationLevel = new EducationLevelModel
                    {
                        Id = model.EducationLevel?.Id ?? 0,
                        LevelName = model.EducationLevel != null ? model.EducationLevel.LevelName : ""
                    },
                    Colour = new ColourModel
                    {
                        id = model.Colour?.id ?? 0,
                        ColourName = model.Colour != null ? model.Colour.ColourName : "",

                    },
                    Municipality = new MunicipalityModel
                    {
                        Id = model.Municipality?.Id ?? 0,
                        MunicipalityName = model.Municipality != null ? model.Municipality.MunicipalityName : "",
                        MuniTypeId = model.Municipality.MuniTypeId ?? 0,
                        MunType = new MuncipalityTypeModel
                        {
                            MuniType = model.Municipality != null ? model.Municipality.MunicipalityType.MuniType : "",

                        },
                        District = new DistrictModel
                        {
                            DistrictCode = model.Municipality != null ? Convert.ToInt32(model.Municipality.District?.DistrictCode) : 0,
                            DistrictNameEng = model.Municipality != null ? model.Municipality.District.DistrictNameEng : "",
                            State = new StateModel
                            {
                                StateName = model.Municipality != null ? model.Municipality.District.State.StateName : ""
                            }
                        }
                    }



                });
            }

            return missingModelList;
        }
    }

    
}
