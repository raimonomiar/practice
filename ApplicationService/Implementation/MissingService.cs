using ApplicationRepository;
using ApplicationRepository.UnitOfWork;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementation
{
    public class MissingService : IMissingService
    {
        private readonly practiceEntities db;

        private readonly IUnitOfWork unitOfWork;

        public MissingService(IUnitOfWork _unitOfWork =null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();

            db = new practiceEntities();
        }

        public void Add(MissingModel model)
        {
            var missing = Mapper.MissingMapper.MissingModelToMissing(model);

            unitOfWork.MissingRepository.Create(missing);
        }

        public Missing AddMissing(MissingModel model)
        {
            var missing = Mapper.MissingMapper.MissingModelToMissing(model);

           return unitOfWork.MissingRepository.Create(missing);
        }

        public void Delete(object id)
        {
            unitOfWork.MissingRepository.Delete(id);
        }

        public List<MissingModel> ExecuteSpWithParameterForList()
        {
            throw new NotImplementedException();
        }

        public List<MissingModel> FindMissingRecords(string fname, string lname, DateTime? missingDate, int? missingDistrict, int? missingOffice, int? registrationNumber)
        {
            var missingModelLists = new List<MissingModel>();

            using (var db = new practiceEntities())
            {
                var missingModel = db.Missings
                    .Include(x => x.User)
                    .Include(x => x.Office)
                    .Select(x => new MissingModel
                    {
                        Id = x.Id,
                        RegistrationNumber = x.RegistrationNumber,
                        OfficeName = x.Office.OfficeName,
                        Fname = x.Fname,
                        Lname = x.Lname,
                        EnteredDate = x.EnteredDate,
                        Photo = x.Photo,
                        LastSeenDate = x.LastSeenDate,
                        ComplainByName = x.ComplainByName,
                        ComplainContactNumber = x.ComplainContactNumber,
                        MissingStatus = x.MissingStatus,
                        OfficeId = x.OfficeId,
                        MDistrictId = x.MDistrictId,
                        MMunicipalityId = x.MMunicipalityId,
                        ComplainDate = x.ComplainDate,
                        PMunicipalityId = x.PMunicipalityId,
                        PDistrictId = x.PDistrictId,
                        PToleName = x.PToleName,
                        PWardNumber = x.PWardNumber,
                        MToleName = x.MToleName,
                        MWardNumber = x.MWardNumber,
                        MDistrictName = "",
                        MMunicipalityName = "",
                        PDistrictName = "",
                        PMunicipalityName = ""

                    })
                    .OrderByDescending(x => x.Id)
                    .Where(x => x.VerifyStatus.ToUpper() == "V" && (x.Fname.Contains(fname) || x.Lname.Contains(lname)));

                if (fname !="")
                {
                    missingModel = missingModel.Where(x => x.Fname.Contains(fname));
                }

                if (lname !="")
                {
                    missingModel = missingModel.Where(x => x.Lname.Contains(lname));
                }

                if (missingDate != Convert.ToDateTime("1/1/0001"))
                {
                    missingModel = missingModel.Where(x => x.ComplainDate == missingDate);
                }

                if (registrationNumber != null )
                {
                    missingModel = missingModel.Where(x => x.RegistrationNumber == registrationNumber);
                }

                if (missingOffice >0)
                {
                    missingModel = missingModel.Where(x => x.OfficeId == missingOffice);
                }

                if (missingDistrict>0)
                {
                    missingModel = missingModel.Where(x => x.MDistrictId == missingDistrict);
                }

                var missingModelList = missingModel.ToList();

                missingModelLists.AddRange(missingModelList);

                foreach (var model in missingModelLists)
                {
                    model.PDistrictName = model.PDistrictId != null ? db.Districts.SingleOrDefault(x => x.Id == model.PDistrictId)?.DistrictNameEng : "";

                    model.PMunicipalityName = model.PMunicipalityId != null ? db.Municipalities.SingleOrDefault(x => x.Id == model.PMunicipalityId)?.MunicipalityName : "";

                    model.MMunicipalityName = model.MMunicipalityId != null ? db.Municipalities.SingleOrDefault(x => x.Id == model.MMunicipalityId)?.MunicipalityName : "";

                    model.MDistrictName = model.MDistrictId != null ? db.Districts.SingleOrDefault(x => x.Id == model.MDistrictId)?.DistrictNameEng : "";


                }

                return missingModelList;


            }

        }

        public List<MissingModel> FindMissingRecords(string fname, string lname, DateTime? missingDate, int? missingDistrict, int? missingOffice, string registrationNumber)
        {
            throw new NotImplementedException();
        }

        public List<MissingModel> GetAllMissingModels(MissingModel model)
        {
            var mmList = new List<MissingModel>();

            using (var db = new practiceEntities())
            {
                var missingList = db.Missings
                    .Include(x => x.Office)
                    .Include(x => x.User)
                    .Where(x => x.VerifyStatus == "V")
                    .OrderByDescending(x => x.verifydate)
                    .ToList();

                var missingModelList = Mapper.MissingMapper.MissingListToMissingModelList(missingList);

                mmList.AddRange(missingModelList);

                foreach (var missingModel in mmList)
                {
                    missingModel.PDistrictName = missingModel.PDistrictId != null ?
                        db.Districts.SingleOrDefault(x => x.Id == missingModel.PDistrictId)?.DistrictNameEng : "";

                    missingModel.MDistrictName = missingModel.MDistrictId != null ?
                        db.Districts.SingleOrDefault(x => x.Id == missingModel.MDistrictId)?.DistrictNameEng : "";

                    missingModel.PMunicipalityName = missingModel.PMunicipalityId != null ?
                        db.Municipalities.SingleOrDefault(x => x.Id == missingModel.PMunicipalityId)?.MunicipalityName : "";


                    missingModel.MMunicipalityName = missingModel.MMunicipalityId != null ?
                        db.Municipalities.SingleOrDefault(x => x.Id == missingModel.MMunicipalityId)?.MunicipalityName : "";
                }
                return missingModelList;
            }
        }

        public List<MissingModel> GetAllMissingPendingRecords(int pfficeId, int roleId)
        {
            using (var context = new practiceEntities())
            {
                if (roleId==1)
                {
                    var missingModelList = context.Missings
                        .Include(x => x.User)
                        .Include(x => x.Office)
                        .Where(x => x.VerifyStatus.ToUpper() == "P")
                        .OrderByDescending(x => x.Id)
                        .Select(x => new MissingModel
                        {
                            RegistrationNumber=x.RegistrationNumber,
                            Id=x.Id,
                            OfficeName=x.Office.OfficeName,
                            Fname=x.Fname,
                            Lname=x.Lname,
                            EnteredDate =x.EnteredDate,
                            LastSeenDate=x.LastSeenDate,
                            Photo=x.Photo,
                            ComplainByName=x.ComplainByName,
                            ComplainContactNumber =x.ComplainContactNumber,
                            MissingStatus=x.MissingStatus,
                            OfficeId=x.OfficeId,
                            UserId=x.UserId,
                            VerifyStatus=x.VerifyStatus,
                            verifydate=x.verifydate,
                            VerifyUserId=x.VerifyUserId,
                            VerifyMessage=x.VerifyMessage,
                            
                        })
                        .ToList();

                    return missingModelList;
                }
                else
                {
                    var missingModelList = context.Missings
                        .Include(x => x.User)
                        .Include(x => x.Office)
                        .Where(x => x.VerifyStatus.ToUpper() == "P" && x.OfficeId == pfficeId)
                        .OrderByDescending(x => x.Id)
                        .Select(x => new MissingModel
                        {
                            RegistrationNumber = x.RegistrationNumber,
                            Id = x.Id,
                            OfficeName = x.Office.OfficeName,
                            Fname = x.Fname,
                            Lname = x.Lname,
                            EnteredDate = x.EnteredDate,
                            LastSeenDate = x.LastSeenDate,
                            Photo = x.Photo,
                            ComplainByName = x.ComplainByName,
                            ComplainContactNumber = x.ComplainContactNumber,
                            MissingStatus = x.MissingStatus,
                            OfficeId = x.OfficeId,
                            UserId = x.UserId,
                            VerifyStatus = x.VerifyStatus,
                            verifydate = x.verifydate,
                            VerifyUserId = x.VerifyUserId,
                            VerifyMessage = x.VerifyMessage,

                        })
                        .ToList();

                    return missingModelList;

                }
            }
        }

        public List<MissingModel> GetAllMissingUnApprovedRecords(int officeId)
        {
            using (var context = new practiceEntities())
            {
                var missingModelList = context.Missings
                        .Include(x => x.User)
                        .Include(x => x.Office)
                        .Where(x => x.VerifyStatus.ToUpper() == "V" && x.OfficeId == officeId)
                        .OrderByDescending(x => x.Id)
                        .Select(x => new MissingModel
                        {
                            RegistrationNumber = x.RegistrationNumber,
                            Id = x.Id,
                            OfficeName = x.Office.OfficeName,
                            Fname = x.Fname,
                            Lname = x.Lname,
                            EnteredDate = x.EnteredDate,
                            LastSeenDate = x.LastSeenDate,
                            Photo = x.Photo,
                            ComplainByName = x.ComplainByName,
                            ComplainContactNumber = x.ComplainContactNumber,
                            MissingStatus = x.MissingStatus,
                            OfficeId = x.OfficeId,
                            UserId = x.UserId,
                            VerifyStatus = x.VerifyStatus,
                            verifydate = x.verifydate,
                            VerifyUserId = x.VerifyUserId,
                            VerifyMessage = x.VerifyMessage,

                        })
                        .ToList();

                return missingModelList;

            }
        }

        public List<MissingModel> GetAllT()
        {
            var missingList = unitOfWork.MissingRepository.All().ToList();

            var missingModelList = Mapper.MissingMapper.MissingListToMissingModelList(missingList);

            return missingModelList;
        }

        public MissingModel GetEmptyModel() => new MissingModel();

        public IEnumerable<MissingModel> GetMissingPDFReport(DateTime? startDate, DateTime? endDate, string gender, int? districtId, int? officeId, int? statusId, int? fiscalYearId, string personType)
        {
            if (endDate==Convert.ToDateTime("1/1/0001"))
            {
                endDate = DateTime.Now;
            }

            var missingModelList =new List<MissingModel>();

            using (var context = new practiceEntities())
            {
                var missingModel = context.Missings
                    .Include(x => x.Office)
                    .Where(x => x.VerifyStatus.ToUpper() == "V")
                    .OrderBy(x => x.Id)
                    .Select(x => new MissingModel
                    {
                        Id = x.Id,
                        OfficeId = x.OfficeId,
                        OfficeName = x.Office.OfficeName,
                        FiscalYearId = x.FiscalYearId,
                        RegistrationNumber = x.RegistrationNumber,
                        Fname = x.Fname,
                        Lname = x.Lname,
                        Photo = x.Photo,
                        Alias = x.Alias,
                        MaritialStatus = x.MaritialStatus,
                        EthnicityId = x.EthnicityId,
                        Gender = x.Gender,
                        PersonType = x.PersonType,
                        FatherName = x.FatherName,
                        MotherName = x.MotherName,
                        SpouseName = x.SpouseName,
                        SpecialIdentifier = x.SpecialIdentifier,
                        NationalityId = x.NationalityId,
                        IdTypeId = x.IdTypeId,
                        IdTypeNumber = x.IdTypeNumber,
                        ReligionId = x.ReligionId,
                        Occupation = x.Occupation,
                        EducationLevelId = x.EducationLevelId,
                        DOB = x.DOB,
                        EstimatedAge = x.EstimatedAge,
                        Hieght = x.Hieght,
                        Weight = x.Weight,
                        ClothesWorn = x.ClothesWorn,
                        EyeColorId = x.EyeColorId,
                        HairColorId = x.HairColorId,
                        Build = x.Build,
                        TDistrictId = x.TDistrictId,
                        TMunicipalityId = x.TMunicipalityId,
                        TToleName = x.TToleName,
                        TWardNumber = x.TWardNumber,
                        TContactNumber = x.TContactNumber,
                        PDistrictId = x.PDistrictId,
                        PMunicipalityId = x.PMunicipalityId,
                        PContactNumber = x.PContactNumber,
                        PToleName = x.PToleName,
                        PWardNumber = x.PWardNumber,
                        MDistrictId = x.MDistrictId,
                        MMunicipalityId = x.MMunicipalityId,
                        MWardNumber = x.MWardNumber,
                        MToleName = x.MToleName,
                        LastSeenDate = x.LastSeenDate,
                        LastSeenPlace = x.LastSeenPlace,
                        LastSeenTime = x.LastSeenTime,
                        EnteredDate = x.EnteredDate,
                        ComplainDate = x.ComplainDate,
                        RelationWithVictim = x.RelationWithVictim,
                        ComplainByName = x.ComplainByName,
                        ComplainContactNumber = x.ComplainContactNumber,
                        DateOfFound = x.DateOfFound,
                        Remarks = x.Remarks,
                        PossiblePlaces = x.PossiblePlaces,
                        MissingReason = x.MissingReason,
                        MissingStatus = x.MissingStatus,
                        FoundAddress = x.FoundAddress,
                        LiveStatus = x.LiveStatus,
                        FoundRemarks = x.FoundRemarks,
                        FoundByOfficeId = x.FoundByOfficeId,
                        HandOverTo = x.HandOverTo,
                        HandOverDate = x.HandOverDate,
                        HandOverRelation = x.HandOverRelation,
                        HandOverDetails = x.HandOverDetails,
                        HandOverContactNumber = x.HandOverContactNumber,
                        LastSearchActivityDate = x.LastSearchActivityDate,

                    });

                if (startDate!=Convert.ToDateTime("1/1/0001"))
                {
                    missingModel = missingModel.Where(x => x.LastSeenDate >= startDate && x.LastSeenDate <= endDate)
                        .OrderBy(x => x.LastSeenDate);
                }
                if (!String.IsNullOrEmpty(gender))
                {
                    missingModel = missingModel.Where(x => x.Gender == gender);

                }

                if (districtId > 0)
                {
                    missingModel = missingModel.Where(x => x.MDistrictId == districtId);
                }

                if (statusId > 0)
                {
                    missingModel = missingModel.Where(x => x.MissingStatus == statusId);
                }

                if (fiscalYearId > 0)
                {
                    var fy = context.FiscalYears.SingleOrDefault(x => x.Id == fiscalYearId);

                    missingModel = missingModel.Where(x => x.LastSeenDate >= fy.StartDate
                                             && x.LastSeenDate <= fy.EndDate);
                }
                if (!String.IsNullOrEmpty(personType))
                {
                    missingModel = missingModel.Where(x => x.PersonType == personType);
                }

                var missingPdfReportModelList = missingModel.ToList();

                missingModelList.AddRange(missingPdfReportModelList);

                foreach (var item in missingPdfReportModelList)
                {
                    item.TDistrictName = item.TDistrictId != null ?
                        context.Districts.SingleOrDefault(x => x.Id == item.TDistrictId)?.DistrictNameEng : "";

                    item.PDistrictName = item.PDistrictId != null ?
                        context.Districts.SingleOrDefault(x => x.Id == item.PDistrictId)?.DistrictNameEng : "";

                    item.MDistrictName = item.MDistrictId != null ?
                        context.Districts.SingleOrDefault(x => x.Id == item.MDistrictId)?.DistrictNameEng : "";

                    item.TMunicipalityName = item.TMunicipalityId != null ?
                        context.Municipalities.SingleOrDefault(x => x.Id == item.TMunicipalityId)?.MunicipalityName : "";

                    item.PMunicipalityName = item.PMunicipalityId != null ?
                        context.Municipalities.SingleOrDefault(x => x.Id == item.PMunicipalityId)?.MunicipalityName : "";

                    item.MMunicipalityName = item.MMunicipalityId != null ?
                        context.Municipalities.SingleOrDefault(x => x.Id == item.MMunicipalityId)?.MunicipalityName : "";

                    

                }

                return missingPdfReportModelList;

            }
        }

        public IEnumerable<MissingExcelReportModel> GetMissingReport(DateTime? startDate, DateTime? endDate, string gender, int? districtId, int? officeId, int? statusId, int? fiscalYearId, string PersonType)
        {
            if (endDate==Convert.ToDateTime("1/1/0001"))
            {
                endDate = DateTime.Now;
            }

            var missingExcelReportModel = new List<MissingExcelReportModel>();

            using (var context = new practiceEntities())
            {
                var missingExcelReporModel = context.Missings
                    .Include(x => x.Office)
                    .Where(x => x.VerifyStatus.ToUpper() == "V")
                    .OrderByDescending(x => x.Id)
                    .Select(x => new MissingExcelReportModel
                    {
                        MissingId = x.Id,
                        OfficeId = x.OfficeId,
                        OfficeName = x.Office.OfficeName,
                        FiscalYearId = x.FiscalYearId,
                        RegistrationNumber = x.RegistrationNumber.ToString(),
                        FirstName = x.Fname,
                        LName = x.Lname,
                        Photo = x.Photo,
                        Alias = x.Alias,
                        MatrialStatus = x.MaritialStatus,
                        EthnicityId = x.EthnicityId,
                        Gender = x.Gender,
                        PersonType = x.PersonType,
                        FatherName = x.FatherName,
                        MotherName = x.MotherName,
                        SpouseName = x.SpouseName,
                        SpecialIdentifier = x.SpecialIdentifier,
                        NationalityId = x.NationalityId,
                        IdType = x.IdTypeId,
                        IdTypeNumber = x.IdTypeNumber,
                        ReligionId = x.ReligionId,
                        occupation = x.Occupation,
                        EducationLevelId = x.EducationLevelId,
                        Dob = x.DOB,
                        EstimateAge = x.EstimatedAge,
                        Height = x.Hieght,
                        Weight = x.Weight,
                        ClothesWorn = x.ClothesWorn,
                        EyeColorId = x.EyeColorId,
                        HairColorId = x.HairColorId,
                        Build = x.Build,
                        TDistrictId = x.TDistrictId,
                        TMunicipalityId = x.TMunicipalityId,
                        TToleName = x.TToleName,
                        TWardNumber = x.TWardNumber,
                        TContactNumber = x.TContactNumber,
                        PDistrictId = x.PDistrictId,
                        PMunicipalityId = x.PMunicipalityId,
                        PContactNumber = x.PContactNumber,
                        PToleName = x.PToleName,
                        PWardNumber = x.PWardNumber,
                        MDistrictId = x.MDistrictId,
                        MMunicipalityId = x.MMunicipalityId,
                        MWardNumber = x.MWardNumber,
                        MToleName = x.MToleName,
                        LastSeenDate = x.LastSeenDate,
                        LastSeenPlace = x.LastSeenPlace,
                        LastSeenTime = x.LastSeenTime,
                        EnteredDate = x.EnteredDate,
                        ComplaintDate = x.ComplainDate,
                        RelationWithVictim = x.RelationWithVictim,
                        ComplainName = x.ComplainByName,
                        ComplainContactNumber = x.ComplainContactNumber,
                        DateFound = x.DateOfFound,
                        Remarks = x.Remarks,
                        PossiblePlaces = x.PossiblePlaces,
                        MissingReason = x.MissingReason,
                        MissingStatus = x.MissingStatus,
                        FoundAddress = x.FoundAddress,
                        LiveStatus = x.LiveStatus,
                        FoundRemarks = x.FoundRemarks,
                        FoundByOfficeId = x.FoundByOfficeId,
                        HandOverTo = x.HandOverTo,
                        HandOverDate = x.HandOverDate,
                        HandOverRelation = x.HandOverRelation,
                        HandOverDetails = x.HandOverDetails,
                        HandOverContactNumber = x.HandOverContactNumber,
                        LastSearchActivityDate = x.LastSearchActivityDate,

                    });

                if (startDate != Convert.ToDateTime("1/1/0001"))
                {
                    missingExcelReporModel = missingExcelReporModel.Where(x => x.LastSeenDate >= startDate && x.LastSeenDate <= endDate)
                        .OrderBy(x=>x.LastSeenDate);
                }

                if (!String.IsNullOrEmpty(gender))
                {
                    missingExcelReporModel = missingExcelReporModel.Where(x => x.Gender == gender);

                }

                if (districtId>0)
                {
                    missingExcelReporModel = missingExcelReporModel.Where(x => x.MDistrictId == districtId);
                }

                if (statusId>0)
                {
                    missingExcelReporModel = missingExcelReporModel.Where(x => x.MissingStatus == statusId);
                }

                if (fiscalYearId>0)
                {
                    var fy = context.FiscalYears.SingleOrDefault(x => x.Id == fiscalYearId);

                    missingExcelReporModel = missingExcelReporModel.Where(x => x.LastSeenDate >= fy.StartDate
                                             && x.LastSeenDate <= fy.EndDate);
                }
                if (!String.IsNullOrEmpty(PersonType))
                {
                    missingExcelReporModel = missingExcelReporModel.Where(x => x.PersonType == PersonType);
                }

                var missingExcelReportModelList = missingExcelReporModel.ToList();

                missingExcelReportModel.AddRange(missingExcelReportModelList);

                foreach (var item in missingExcelReportModel)
                {
                    item.TDistrictName = item.TDistrictId != null ?
                        context.Districts.SingleOrDefault(x => x.Id == item.TDistrictId)?.DistrictNameEng : "";

                    item.PDistrictName = item.PDistrictId != null ?
                        context.Districts.SingleOrDefault(x => x.Id == item.PDistrictId)?.DistrictNameEng : "";

                    item.MDistrictname = item.MDistrictId != null ?
                        context.Districts.SingleOrDefault(x => x.Id == item.MDistrictId)?.DistrictNameEng : "";

                    item.TMunicipalityName = item.TMunicipalityId != null ?
                        context.Municipalities.SingleOrDefault(x => x.Id == item.TMunicipalityId)?.MunicipalityName : "";

                    item.PMunicipalityname = item.PMunicipalityId != null ?
                        context.Municipalities.SingleOrDefault(x => x.Id == item.PMunicipalityId)?.MunicipalityName : "";

                    item.MMunicipalityName = item.MMunicipalityId != null ?
                        context.Municipalities.SingleOrDefault(x => x.Id == item.MMunicipalityId)?.MunicipalityName : "";

                    item.IdTypeNumber = item.IdType != null ?
                        context.IdTypes.SingleOrDefault(x => x.id == item.IdType)?.IdTypeName : "";

                    item.NationalityName = item.NationalityId != null ?
                        context.countries.SingleOrDefault(x => x.Id == item.NationalityId)?.CountryName : "N/A";

                    item.ReligionName = item.ReligionId != null ?
                        context.Religions.SingleOrDefault(x => x.Id == item.ReligionId)?.ReligionName : "";

                    item.EducationLevelName = item.EducationLevelId != null ?
                        context.EducationLevels.SingleOrDefault(x => x.Id == item.EducationLevelId)?.LevelName : "";



                }

                return missingExcelReportModelList;
            }
        }

        public MissingModel GetOneMissingModel(object id)
        {
            using (practiceEntities db = new practiceEntities())
            {
                MissingModel missingModel = null;
                try
                {
                    var Id = Convert.ToInt32(id);

                    var missing = db.Missings
                        .Include(x => x.Religion)
                        .Include(x => x.country)
                        .Include(x => x.EducationLevel)
                        .Include(x => x.Colour)
                        .Include(x => x.IdType)
                        .Include(x => x.User)
                        .SingleOrDefault(x => x.Id == Id);

                    missingModel = Mapper.MissingMapper.MissingToMissingModel(missing);

                    if (missing!=null)
                    {

                        missingModel.Verifier = unitOfWork.UserRepository
                            .Get(x=>x.UserId == missing.UserId)
                            .SingleOrDefault()
                            .Username;

                        missingModel.HairColor = unitOfWork.ColourRepository
                            .Get(x => x.id == missing.HairColorId)
                            .SingleOrDefault()
                            .ColourName;

                        missingModel.EyeColor = unitOfWork.ColourRepository
                            .Get(x => x.id == missing.EyeColorId)
                            .SingleOrDefault()
                            .ColourName;

                        missingModel.PMunicipalityName = unitOfWork.MunicipalityRepository
                            .Get(x => x.Id == missing.PMunicipalityId)
                            .SingleOrDefault()
                            .MunicipalityName;

                        missingModel.TMunicipalityName = unitOfWork.MunicipalityRepository
                            .Get(x => x.Id == missing.TMunicipalityId)
                            .SingleOrDefault()
                            .MunicipalityName;

                        missingModel.MMunicipalityName = unitOfWork.MunicipalityRepository
                            .Get(x => x.Id == missing.MMunicipalityId)
                            .SingleOrDefault()
                            .MunicipalityName;

                        missingModel.PState = unitOfWork.StateRepository
                            .Get(x => x.StateId == missing.PStateId)
                            .SingleOrDefault()
                            .StateName;

                        missingModel.TState = unitOfWork.StateRepository
                            .Get(x => x.StateId == missing.TStateId)
                            .SingleOrDefault()
                            .StateName;

                        missingModel.MState = unitOfWork.StateRepository
                            .Get(x => x.StateId == missing.MStateId)
                            .SingleOrDefault()
                            .StateName;

                        missingModel.TDistrictName = unitOfWork.DistrictRepository
                            .Get(x => x.Id == missing.TDistrictId)
                            .SingleOrDefault()
                            .DistrictNameEng;

                        missingModel.MDistrictName = unitOfWork.DistrictRepository
                            .Get(x => x.Id == missing.MDistrictId)
                            .SingleOrDefault()
                            .DistrictNameEng;

                        missingModel.PDistrictName = unitOfWork.DistrictRepository
                            .Get(x => x.Id == missing.PDistrictId)
                            .SingleOrDefault()
                            .DistrictNameEng;

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return missingModel;
            }
        }

        public MissingModel GetOneModel(int Id)
        {
            var missing = unitOfWork.MissingRepository.GetById(Id);

            var missingModel = Mapper.MissingMapper.MissingToMissingModel(missing);

            return missingModel;
        }

        public IEnumerable<MissingModel> MissingMatches(MissingModel model)
        {
            var missingModelList = new List<MissingModel>();

            using (var context = new practiceEntities())
            {
                missingModelList = context.spMissingMatches(model.Fname, model.Lname, model.Alias, model.DOB, model.Gender, model.FatherName, model.MotherName)
                    .Select(x=>new MissingModel
                    {
                        Id = x.Id,
                        Fname = x.Fname,
                        Lname= x.Lname,
                        Photo=x.Photo,
                        ComplainByName=x.ComplainByName,
                        ComplainDate=x.ComplainDate,
                        EnteredDate=x.EnteredDate,
                        OfficeName =x.OfficeName

                    })
                    .ToList();


            }
                return missingModelList;
        }

        public bool RegistrationNumberExist(int officeId, int fiscalYearId, int registrationNumber, int missingId = 0)
        {
            bool exists;

            if (missingId==0)
            {
                exists = unitOfWork.MissingRepository.Get(x => x.OfficeId == officeId
                && x.FiscalYearId == fiscalYearId && x.RegistrationNumber == registrationNumber)
                .Any();
            }
            else
            {
                exists = unitOfWork.MissingRepository.Get(x => x.OfficeId == officeId
                && x.FiscalYearId == fiscalYearId && x.RegistrationNumber == registrationNumber
                && x.Id != missingId)
                .Any();
            }

            return exists;
        }

        public void Update(MissingModel model)
        {
            var missingOld = unitOfWork.MissingRepository.GetById(model.Id);

            var missingNew = Mapper.MissingMapper.MissingModelToMissing(model);

            unitOfWork.MissingRepository.Update(missingOld, missingNew);
        }
    }
}
