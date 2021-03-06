using System.Globalization;
using Credit.CreditLevelModels;
using Credit.CreditLevelServices.Interfaces;
using Credit.OrderModels;
using Credit.SettingServices;
using Credit.SettingServices.Dtos;
using Credit.TeamModels;
using Credit.UserModels;
using Credit.UserServices.Dtos;
using Credit.UserWalletModels;
using Data.Commons.Dtos;
using Data.Commons.Enums;
using Data.Commons.Extensions;
using Data.Commons.Helpers;
using Data.Commons.Runtime;

namespace Credit.UserServices
{
    /// <summary>
    ///  用户管理接口方法实现
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IFreeSql _freeSql;
        private readonly ITokenManager _tokenManager;
        private readonly ICreditLevelService _creditLevelService;
        private readonly ISettingService _settingService;

        /// <summary>
        /// 
        /// </summary>
        public UserService(IFreeSql freeSql,
            ITokenManager tokenManager,
            ICreditLevelService creditLevelService,
            ISettingService settingService)
        {
            _freeSql = freeSql;
            _tokenManager = tokenManager;
            _creditLevelService = creditLevelService;
            _settingService = settingService;
        }

        /// <summary>
        ///  邀请码是否存在
        /// </summary>
        /// <param name="invCode"></param>
        /// <returns></returns>
        private async Task<bool> InvCodeAny(string invCode)
        {
            return await _freeSql.Select<Users>()
                .Where(s => s.InvCode == invCode)
                .AnyAsync();
        }

        /// <summary>
        ///  注册用户
        /// </summary>
        /// <param name="input"></param>
        public async Task<string> RegisterUser(RegisterUserInput input)
        {
            if (string.IsNullOrEmpty(input.Username))
                return "Please enter your username";
            if (string.IsNullOrEmpty(input.Password))
                return "Please enter your password";
            if (input.Password.Length < 6)
                return "Password must be at least 6 characters long";
            if (string.IsNullOrEmpty(input.ConfirmPassword))
                return "Please confirm your password";
            if (input.Password != input.ConfirmPassword)
                return "Password does not match";
            //账号是否已存在
            var nameExist = await _freeSql.Select<Users>()
                    .Where(s => s.Username == input.Username)
                    .AnyAsync();
            //父级用户ID
            var parentUserId = 0l;
            //团队根级Id
            var rootParentId = 0l;
            //上级
            Users parentUser = null;
            //邀请积分
            var invIntegral = 0;
            // 邀请码是否正确
            if (!string.IsNullOrEmpty(input.InvCode))
            {
                parentUser = await _freeSql.Select<Users>()
                    .Where(s => s.InvCode == input.InvCode)
                    .Where(s => s.IsDeleted == 0)
                    .ToOneAsync();
                if (parentUser == null)
                    throw new MyException("Invitation code error");
                parentUserId = parentUser.Id;
                rootParentId = parentUser.RootParentId;
                var taskSetting = await _settingService.GetSetting<TaskIntegralSetting>();
                invIntegral = taskSetting.InvitationIntegral;
            }

            //用户邀请码
            var invCode = GetRandomString(6);
            var invCodeExist = await InvCodeAny(invCode);
            while (invCodeExist)
            {
                invCode = GetRandomString(6);
                invCodeExist = await InvCodeAny(invCode);
            }

            //默认信用等级
            var defaultCredit = await _freeSql.Select<CreditLevel>()
                .Where(s => s.IsDeleted == 0 && s.CreditValue <= 0)
                .ToOneAsync();

            var userId = IdHelper.GetId();
            var user = new Users
            {
                Id = userId,
                Username = input.Username.ToLower(),
                Password = input.Password,
                Nickname = input.Nickname,
                CountryName = input.CountryName,
                Code = input.Code,
                InvCode = invCode,
                ParentId = parentUserId,
                RootParentId = rootParentId == 0 ? rootParentId : userId,
                TeamLevel = 0,
                CreditValue = 0,
                Level = defaultCredit?.Id ?? 0, //信用等级
                IsAdmin = input.IsAdmin,
            };

            //事务开始
            using (var uow = _freeSql.CreateUnitOfWork())
            {
                var userRepository = _freeSql.GetRepository<Users>();
                userRepository.UnitOfWork = uow;
                //添加新用户
                await userRepository.InsertAsync(user);
                //增加邀请人积分和邀请人邀请人数
                if (parentUserId > 0 && parentUser != null)
                {
                    parentUser.InviteCount += 1;
                    parentUser.Integral += invIntegral;
                    await userRepository.UpdateAsync(parentUser);
                }
                uow.Commit();
            }
            return "register_success";
        }
        /// <summary>
        /// 生成邀请
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public string GetRandomString(int len)
        {
            string s = "123456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";
            string reValue = string.Empty;
            Random rd = new Random();
            while (reValue.Length < len)
            {
                string s1 = s[rd.Next(0, s.Length)].ToString();
                if (reValue.IndexOf(s1) == -1)
                    reValue += s1;
            }
            return reValue;
        }
        /// <summary>
        ///  用户登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<UserLoginOutput> UserLogin(UserLoginInput input)
        {
            UserLoginOutput output = new UserLoginOutput();
            if (string.IsNullOrEmpty(input.Username))
            {
                output.Msg = "Please enter your username";
                return output;
            }
            if (string.IsNullOrEmpty(input.Password))
            {
                output.Msg = "Please enter your password";
                return output;
            }
            var user = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0)
                .Where(s => s.Username == input.Username.ToLower())
                .Where(s => s.IsAdmin == 0)
                .ToOneAsync();
            if (user == null)
            {
                output.Msg = "Username does not exist";
                return output;
            }
            if (user.Password != input.Password)
            {
                output.Msg = "Wrong password";
                return output;
            }
            var userToken = new UserLoginDto
            {
                UserId = user.Id,
                Username = user.Username,
                Nickname = user.Nickname,
                HeadImage = user.HeadImage
            };
            var token = await _tokenManager.GenerateToken(userToken, 24 * 608 * 60);
            output.User = userToken;
            output.Token = token;
            output.Msg = "logon_success";
            return output;
        }

        /// <summary>
        ///  管理员登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="MyException"></exception>
        public async Task<UserLoginOutput> AdminUserLogin(UserLoginInput input)
        {
            if (string.IsNullOrEmpty(input.Username))
                throw new MyException("Please enter your username");
            if (string.IsNullOrEmpty(input.Password))
                throw new MyException("Please enter your password");
            var user = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0)
                .Where(s => s.Username == input.Username.ToLower())
                .Where(s => s.IsAdmin == 1)
                .ToOneAsync();
            if (user == null)
                throw new MyException("Username does not exist");
            if (user.Password != input.Password)
                throw new MyException("Wrong password");
            var userToken = new AdminLoginDto
            {
                UserId = user.Id,
                Username = user.Username,
                Nickname = user.Nickname,
                HeadImage = user.HeadImage,
                IsAdmin = 1
            };
            var token = await _tokenManager.GenerateToken(userToken, 24 * 608 * 60);
            var output = new UserLoginOutput
            {
                User = userToken,
                Token = token
            };
            return output;
        }

        /// <summary>
        ///  新建用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateUser(UserInput input)
        {
            var user = new Users
            {
                Id = IdHelper.GetId(),
                Nickname = input.Nickname,
                Username = input.Username,
                Password = input.Password
            };
            await _freeSql.Insert(user).ExecuteAffrowsAsync();
        }

        /// <summary>
        ///  修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> UpdateUser(UserInput input)
        {

            var UserInfo = await _freeSql.Select<Users>()
                .Where(s => s.Id == input.Id)
                .ToOneAsync();
            UserInfo.Nickname = input.Nickname;
            UserInfo.HeadImage = input.HeadImage;
            await _freeSql.Update<Users>().SetSource(UserInfo).ExecuteAffrowsAsync();
            return "success";
        }
        /// <summary>
        ///  获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDto> GetUserById(long userId)
        {
            var user = await _freeSql.Select<Users>()
                    .Where(s => s.Id == userId)
                    .ToOneAsync();
            return user.MapTo<UserDto>();
        }
        /// <summary>
        /// 获取信用等级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserCreditDto> GetCreditLevleById(long userId)
        {
            var UserLevel = new UserCreditDto();
            var user = await _freeSql.Select<Users>()
                    .Where(s => s.Id == userId)
                    .ToOneAsync();
            if (user.Level > 0)
            {
                var Level = await _creditLevelService.GetCreditLevel(user.Level);
                UserLevel.UserId = user.Id;
                UserLevel.Nickname = user.Nickname;
                UserLevel.LevelId = Level.Id;
                UserLevel.LevelName = Level.LevelName;
                UserLevel.CreditValue = user.CreditValue;
                UserLevel.ChakaNum = Level.ChakaNum;
                UserLevel.Profit = Level.Profit;
            }

            return UserLevel.MapTo<UserCreditDto>();
        }
        /// <summary>
        ///  获取用户团队人数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserTeamDto> GetTeamCountById(long userId)
        {
            //查询用户
            var user = await _freeSql.Select<Users>()
                    .Where(s => s.Id == userId)
                    .ToOneAsync();
            var DirectCount = await _freeSql.Select<Users>()
                    .Where(s => s.ParentId == user.Id && s.IsTeamUser == 1 && s.Id != userId)
                    .ToListAsync();
            var TeamUserCount = await _freeSql.Select<Users>()
                    .Where(s => s.RootParentId == user.RootParentId && s.IsTeamUser == 1 && s.RootParentId != 0 && s.Id != userId)
                    .ToListAsync();
            var output = new UserTeamDto
            {
                Direct = DirectCount.Count,
                TeamUser = TeamUserCount.Count
            };
            return output;
        }
        /// <summary>
        ///  收益统计
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserProfitDto> GetUserProfitById(long userId)
        {
            //查询用户
            var user = await _freeSql.Select<Users>()
                    .Where(s => s.Id == userId)
                    .ToOneAsync();
            //查卡
            var CKRepayment = await _freeSql.Select<UserWalletRecord>()
                 .Where(s => s.UserId == userId && s.SourceType == WalletSourceEnums.CardRepayment)
                 .ToListAsync();
            var CKAmountCount = CKRepayment.Sum(s => s.Amount);

            //理财
            var SEMFinancil = await _freeSql.Select<UserWalletRecord>()
                 .Where(s => s.UserId == userId && s.SourceType == WalletSourceEnums.FinancilProfit)
                 .ToListAsync();
            var SEMCount = SEMFinancil.Sum(s => s.Amount);

            //团队收益
            //团队注册人数
            var TeamRegisterCount = await _freeSql.Select<Users>()
                    .Where(s => s.RootParentId == user.RootParentId && s.RootParentId != 0)
                    .ToListAsync();
            //成为团员的人数
            var TeamMemberCount = await _freeSql.Select<Users>()
                    .Where(s => s.RootParentId == user.RootParentId && s.IsTeamUser == 1 && s.RootParentId != 0)
                    .ToListAsync();

            //团队代还总金额
            decimal TeamRepaymentCount = 0;
            foreach (var item in TeamMemberCount)
            {
                var TeamRepayment = await _freeSql.Select<UserWalletRecord>()
                     .Where(s => s.UserId == item.Id && s.SourceType == WalletSourceEnums.CardRepayment)
                     .ToListAsync();
                var AmountCount = TeamRepayment.Sum(s => s.Amount);
                TeamRepaymentCount += AmountCount;//
            }
            decimal TeamSemCount = 0;
            foreach (var item in TeamMemberCount)
            {
                var TeamFinancilProfit = await _freeSql.Select<UserWalletRecord>()
                     .Where(s => s.UserId == item.Id && s.SourceType == WalletSourceEnums.FinancilProfit)
                     .ToListAsync();
                var FinancilProfitCount = TeamFinancilProfit.Sum(s => s.Amount);
                TeamSemCount += FinancilProfitCount;//
            }
            decimal TeamEstimateRepaymentRevenue = 0;
            decimal TeamEstimatePurchaseRevenue = 0;
            if (user.TeamLevel != 0)
            {
                //用户团队等级
                var UserTeamLevel = await _freeSql.Select<TeamLevel>()
                    .Where(s => s.Id == user.TeamLevel)
                    .ToOneAsync();
                TeamEstimateRepaymentRevenue = UserTeamLevel.TeamRepayRate * TeamRepaymentCount * 0.01m;
                TeamEstimatePurchaseRevenue = UserTeamLevel.TeamRepayRate * TeamSemCount * 0.01m;
            }
            var TotalRevenue = TeamEstimatePurchaseRevenue + TeamEstimatePurchaseRevenue;
            var output = new UserProfitDto
            {
                ChaKaProfit = CKAmountCount,
                TeamProfit = TotalRevenue,
                SMEProfit = SEMCount
            };
            return output;
        }
        /// <summary>
        ///  获取用户团队收益信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserTeamInfoDto> GetUserTeamCountById(long userId)
        {
            //查询用户
            var user = await _freeSql.Select<Users>()
                    .Where(s => s.Id == userId)
                    .ToOneAsync();
            //团队注册人数
            var TeamRegisterCount = await _freeSql.Select<Users>()
                    .Where(s => s.RootParentId == user.RootParentId && s.RootParentId != 0 && s.Id != userId)
                    .ToListAsync();
            //成为团员的人数
            var TeamMemberCount = await _freeSql.Select<Users>()
                    .Where(s => s.RootParentId == user.RootParentId && s.IsTeamUser == 1 && s.RootParentId != 0 && s.Id != userId)
                    .ToListAsync();

            //团队代还总金额
            decimal TeamRepaymentCount = 0;
            foreach (var item in TeamMemberCount)
            {
                var TeamRepayment = await _freeSql.Select<UserWalletRecord>()
                     .Where(s => s.UserId == item.Id && s.SourceType == WalletSourceEnums.CardRepayment)
                     .ToListAsync();
                var AmountCount = TeamRepayment.Sum(s => s.Amount);
                TeamRepaymentCount += AmountCount;//
            }
            decimal TeamSemCount = 0;
            foreach (var item in TeamMemberCount)
            {
                var TeamFinancilProfit = await _freeSql.Select<UserWalletRecord>()
                     .Where(s => s.UserId == item.Id && s.SourceType == WalletSourceEnums.FinancilProfit)
                     .ToListAsync();
                var FinancilProfitCount = TeamFinancilProfit.Sum(s => s.Amount);
                TeamSemCount += FinancilProfitCount;//
            }


            decimal TeamEstimateRepaymentRevenue = 0;
            decimal TeamEstimatePurchaseRevenue = 0;
            if (user.TeamLevel != 0)
            {
                //用户团队等级
                var UserTeamLevel = await _freeSql.Select<TeamLevel>()
                    .Where(s => s.Id == user.TeamLevel)
                    .ToOneAsync();
                TeamEstimateRepaymentRevenue = UserTeamLevel.TeamRepayRate * TeamRepaymentCount * 0.01m;
                TeamEstimatePurchaseRevenue = UserTeamLevel.TeamRepayRate * TeamSemCount * 0.01m;
            }


            var userTeam = await GetUserTeamChildMembers(userId, 2);

            var output = new UserTeamInfoDto
            {
                UserId = userId,
                TeamRegister = TeamRegisterCount.Count,
                TeamMember = TeamMemberCount.Count,
                TeamRepayment = TeamRepaymentCount,
                TeamEstimateRepaymentRevenue = TeamEstimateRepaymentRevenue,
                TeamEstimatePurchaseRevenue = TeamEstimatePurchaseRevenue,
                TotalRevenue = TeamEstimatePurchaseRevenue + TeamEstimatePurchaseRevenue
            };
            return output;
        }


        /// <summary>
        ///   获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PagedOutput<UserDto>> GetUserPagedList(PagedInput input)
        {
            var list = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0)
                .OrderByDescending(s => s.CreateAt)
                .Count(out long totalCount)
                .Page(input.PageIndex, input.PageSize)
                .ToListAsync();
            var output = new PagedOutput<UserDto>
            {

                TotalCount = totalCount,
                Items = list.MapToList<UserDto>()
            };

            return output;
        }
        /// <summary>
        ///  用户积分转余额
        /// </summary>
        /// <param name="input"></param>
        public void ExchangeIntegral(UserDto input)
        {
            //修改用户余额信息
            _freeSql.Update<Users>(input.Id)
                .SetDto(new { Balance = input.Balance, Integral = input.Integral }).ExecuteAffrows();
        }
        /// <summary>
        /// 增加用户积分
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="Integral"></param>
        /// <returns></returns>
        public async Task AddUserJF(long userId, int Integral)
        {
            var user = await _freeSql.Select<Users>()
            .Where(s => s.Id == userId)
            .ToOneAsync();
            user.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            user.Integral = user.Integral + Integral;
            await _freeSql.Update<Users>().SetSource(user).ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 增加用户信用值
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="CreditValue"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddUserXYZ(long userId, int CreditValue)
        {
            var user = await _freeSql.Select<Users>()
           .Where(s => s.Id == userId)
           .ToOneAsync();
            user.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            user.CreditValue = user.CreditValue + CreditValue;

            await _freeSql.Update<Users>().SetSource(user).ExecuteAffrowsAsync();
            //增加信用等级
            await UpdateCreditLevel(userId);
        }

        public int SelectUserTeam(long userId)
        {
            return 0;
        }

        /// <summary>
        ///  获取团队所有成员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private async Task<List<Users>> GetTeamUserAllMembers(long userId)
        {
            var output = new List<Users>();
            var user = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0)
                .Where(s => s.Id == userId)
                .ToOneAsync();
            if (user == null)
                return output;
            output.Add(user);
            var rootParentId = user.RootParentId > 0 ? user.RootParentId : user.Id;
            var users = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0 && s.IsTeamUser == 1 && s.Id != userId)
                .Where(s => s.RootParentId == rootParentId)
                .ToListAsync();
            output.AddRange(users);
            return output;
        }

        /// <summary>
        ///  获取用户团队父级成员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="maxSort"></param>
        /// <returns></returns>
        public async Task<List<TeamUsersDto>> GetUserTeamParentMembers(long userId, int maxSort = 0)
        {
            var output = new List<TeamUsersDto>();
            output.Add(new TeamUsersDto
            {
                UserId = userId,
                LevelSort = 0
            });
            var teamUsers = await GetTeamUserAllMembers(userId);
            var parentId = teamUsers.FirstOrDefault(s => s.Id == userId)?.ParentId ?? 0;
            var parentMembers = await TeamParentMembers(parentId, teamUsers, maxSort, 1);
            output.AddRange(parentMembers);
            return output;
        }

        /// <summary>
        /// 获取父级成员
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="teamUsers"></param>
        /// <param name="maxSort"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        private async Task<List<TeamUsersDto>> TeamParentMembers(long parentId, List<Users> teamUsers, int maxSort, int sort = 0)
        {
            var output = new List<TeamUsersDto>();
            var user = teamUsers.FirstOrDefault(s => s.Id == parentId);
            if (user == null)
                return output;
            output.Add(new TeamUsersDto
            {
                UserId = parentId,
                LevelSort = sort
            });
            if (user.ParentId == 0 || (maxSort > 0 && maxSort == sort))
                return output;
            var members = await TeamParentMembers(user.ParentId, teamUsers, maxSort, sort + 1);
            output.AddRange(members);

            return output;
        }

        /// <summary>
        ///  获取用户团队子级成员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="maxSort"></param>
        /// <returns></returns>
        public async Task<List<TeamUsersDto>> GetUserTeamChildMembers(long userId, int maxSort = 0)
        {
            var output = new List<TeamUsersDto>();
            output.Add(new TeamUsersDto
            {
                UserId = userId,
                LevelSort = 0
            });
            var teamUsers = await GetTeamUserAllMembers(userId);
            var parentId = teamUsers.FirstOrDefault(s => s.Id == userId)?.ParentId ?? 0;
            var parentMembers = await TeamChildMembers(parentId, teamUsers, maxSort, 1);
            output.AddRange(parentMembers);
            return output;
        }

        /// <summary>
        ///  成为团队人员
        /// </summary>
        /// <param name="userId"></param>
        public async Task UserBecomeTeamUser(long userId)
        {
            var user = await _freeSql.Select<Users>()
                .Where(s => s.IsDeleted == 0 && s.IsTeamUser == 0)
                .ToOneAsync();
            if (user == null)
                return;
            Users parentUser = null;
            if (user.ParentId > 0)
            {
                parentUser = await _freeSql.Select<Users>()
                    .Where(s => s.Id == user.ParentId)
                    .ToOneAsync();
                if (parentUser != null)
                {
                    parentUser.DirectCount = parentUser.DirectCount + 1;
                }
            }

            using (var uow = _freeSql.CreateUnitOfWork())
            {
                await _freeSql.Update<Users>(user.Id)
                    .SetDto(new { IsTeamUser = 1 })
                    .ExecuteAffrowsAsync();
                //增加直接团队成员
                if (parentUser != null)
                {
                    await _freeSql.Update<Users>().SetSource(parentUser).ExecuteAffrowsAsync();
                }
                //更新团队等级
                await UpdateTeamLevel(user.ParentId);
            }
        }

        /// <summary>
        ///  更新用户团队等级
        /// </summary>
        /// <param name="userId"></param>
        public async Task UpdateTeamLevel(long userId)
        {
            var users = await _freeSql.Select<Users>()
                .WhereIf(userId > 0, s => s.Id == userId)
                .Where(s => s.IsDeleted == 0 && s.IsTeamUser == 1)
                .ToListAsync();

            var teamLevels = await _freeSql.Select<TeamLevel>()
                .Where(s => s.IsDeleted == 0)
                .ToListAsync();

            users.ForEach(item =>
            {
                var level = teamLevels.Where(s => s.InviteCount <= item.DirectCount)
                    .OrderBy(s => s.LevelSort)
                    .FirstOrDefault();
                if (level != null)
                    item.TeamLevel = level.Id;
                else
                {
                    item.TeamLevel = 0;
                }
            });
            await _freeSql.Update<Users>()
                .SetSource(users)
                .ExecuteAffrowsAsync();
        }

        /// <summary>
        ///  更新用户信用等级
        /// </summary>
        /// <param name="userId"></param>
        public async Task UpdateCreditLevel(long userId)
        {
            var users = await _freeSql.Select<Users>()
                .WhereIf(userId > 0, s => s.Id == userId)
                .Where(s => s.IsDeleted == 0)
                .ToListAsync();

            var creditLevels = await _freeSql.Select<CreditLevel>()
                .Where(s => s.IsDeleted == 0)
                .ToListAsync();

            users.ForEach(item =>
            {
                var level = creditLevels.Where(s => s.CreditValue <= item.CreditValue)
                    .OrderBy(s => s.LevelSort)
                    .FirstOrDefault();
                if (level != null)
                    item.Level = level.Id;
                else
                {
                    item.Level = 0;
                }
            });
            await _freeSql.Update<Users>()
                .SetSource(users)
                .ExecuteAffrowsAsync();
        }

        /// <summary>
        ///  获取用户任务完成情况
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserTaskCompletedCountDto> GetUserTaskCompletedCount(long userId)
        {
            //获取今日信用卡还款次数
            var dayStart = DateTimeHelper.DayStart();
            var dayCardRepayCount = await _freeSql.Select<UserMoneyApply>()
                .WhereTableTime(TableTimeFormat.Year, dayStart)
                .Where(s => s.SourceType == WalletSourceEnums.CardRepayApply
                && s.UserId == userId)
                .Where(s => s.AuditStatus == AuditStatusEnums.Success
                            && s.IsDeleted == 0)
                .CountAsync();
            //获取本周贷款还款次数
            var weekStart = DateTimeHelper.WeekMondayStart();
            var weekLoanRepayCount = await _freeSql.Select<UserMoneyApply>()
                .WhereTableTime(TableTimeFormat.Year, weekStart)
                .Where(s => s.SourceType == WalletSourceEnums.LoanRepayApply
                            && s.UserId == userId)
                .Where(s => s.AuditStatus == AuditStatusEnums.Success
                            && s.IsDeleted == 0)
                .CountAsync();
            return new UserTaskCompletedCountDto
            {
                DayCardRepayCount = dayCardRepayCount,
                WeekLoanRepayCount = weekLoanRepayCount
            };
        }

        /// <summary>
        /// 获取子级成员
        /// </summary>
        /// <param name="parentId"></param>
        /// .
        /// <param name="teamUsers"></param>
        /// <param name="maxSort"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        private async Task<List<TeamUsersDto>> TeamChildMembers(long parentId, List<Users> teamUsers, int maxSort, int sort = 0)
        {
            var output = new List<TeamUsersDto>();
            var users = teamUsers.Where(s => s.ParentId == parentId).ToList();
            if (users.Count == 0)
                return output;
            output.Add(new TeamUsersDto
            {
                UserId = parentId,
                LevelSort = sort
            });
            if (maxSort == sort && maxSort > 0)
                return output;
            sort += 1;
            foreach (var user in users)
            {
                var members = await TeamChildMembers(user.Id, teamUsers, maxSort, sort);
                output.AddRange(members);
            }

            return output;
        }

        public async Task<string> UpdateUserPwd(long userId, string oldPwd, string newPwd)
        {
            var UserInfo = await _freeSql.Select<Users>()
                .Where(s => s.Id == userId)
                .ToOneAsync();
            if (UserInfo.Password != oldPwd)
                return "Old password error";
            UserInfo.Password = newPwd;
            await _freeSql.Update<Users>().SetSource(UserInfo).ExecuteAffrowsAsync();
            return "success";
        }

        public async Task CreateAdminUser(AdminUserDto input)
        {
            var user = new Users
            {
                Id = IdHelper.GetId(),
                Nickname = input.Nickname,
                Username = input.Username,
                Password = input.Password,
                HeadImage = input.HeadImage,
                IsAdmin = 1,
            };
            await _freeSql.Insert(user).ExecuteAffrowsAsync();
        }

        public async Task<string> UpdateAdminUser(AdminUserDto input)
        {
            var UserInfo = await _freeSql.Select<Users>()
              .Where(s => s.Id == input.Id)
              .ToOneAsync();
            UserInfo.Nickname = input.Nickname;
            UserInfo.HeadImage = input.HeadImage;
            await _freeSql.Update<Users>().SetSource(UserInfo).ExecuteAffrowsAsync();
            return "success";
        }
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedOutput<AdminUserDto>> GetAdminUserPagedList(UserPagedInput input)
        {
            var list = await _freeSql.Select<Users>()
            .Where(s => s.IsDeleted == 0 && s.IsAdmin == 1)
            .WhereIf(!string.IsNullOrEmpty(input.UserName), s => s.Username.Contains(input.UserName))
            .Count(out long totalCouunt)
            .OrderByDescending(s => s.UpdateAt)
            .Page(input.PageIndex, input.PageSize)
            .ToListAsync();
            var output = new PagedOutput<AdminUserDto>
            {
                TotalCount = totalCouunt,
                Items = list.MapToList<AdminUserDto>()
            };
            return output;
        }

        public async Task UserDelete(long userId, long deleteUserId)
        {
            var user = await _freeSql.Select<Users>()
           .Where(s => s.Id == userId)
           .Where(s => s.IsDeleted == 0)
           .ToOneAsync();
            if (user == null)
                throw new MyException("Delete data does not exist");
            user.IsDeleted = 1;
            user.UpdateAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            user.DeleteUserId = deleteUserId;
            await _freeSql.Update<Users>().SetSource(user).ExecuteAffrowsAsync(); 
        }

        public async Task<PagedOutput<UserDto>> GetUserPagedList(UserPagedInput input)
        {
            var list = await _freeSql.Select<Users>()
           .Where(s => s.IsDeleted == 0 && s.IsAdmin == 0)
           .WhereIf(!string.IsNullOrEmpty(input.UserName), s => s.Username.Contains(input.UserName))
           .Count(out long totalCouunt)
           .OrderByDescending(s => s.UpdateAt)
           .Page(input.PageIndex, input.PageSize)
           .ToListAsync();
            var output = new PagedOutput<UserDto>
            {
                TotalCount = totalCouunt,
                Items = list.MapToList<UserDto>()
            };
            return output;
        }
    }
}