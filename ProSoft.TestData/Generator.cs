using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProSoft.TestData
{
    public class Generator
    {
        public class TelephoneGenerator
        {
            private string[] _telNumbers;
            private string[] _telNumbersDiallingCodes;
            private string[] _telNumbersMainNumber;
            private string[] _mobileNumbers;

            public TelephoneGenerator()
            {
                LoadDefaultParameters();
            }

            public TelephoneGenerator(ExternalParams externalParams)
            {
                LoadDefaultParameters();
                LoadExternalParameters(externalParams);
            }

            private void LoadDefaultParameters()
            {
                _telNumbers = InternalParams.TelNos.Split(',');
                _mobileNumbers = InternalParams.MobileNos.Split(',');
                _telNumbersDiallingCodes = InternalParams.TelNoDiallingCodes.Split(',');
                _telNumbersMainNumber = InternalParams.TelNoMainNumbers.Split(',');
            }

            private void LoadExternalParameters(ExternalParams externalParams)
            {
                if (!string.IsNullOrEmpty(externalParams.TelNos)) _telNumbers = externalParams.TelNos.Split(',');
                if (!string.IsNullOrEmpty(externalParams.MobileNos)) _mobileNumbers = externalParams.MobileNos.Split(',');
            }

            public List<string> CreateTelNumberList(bool randomiseDiallingCodes = true)
            {
                List<string> telNoList = new List<string>();

                if (!randomiseDiallingCodes)
                {
                    Random rnd = new Random(Environment.TickCount);
                    int lastCount = _telNumbers.Length;

                    for (int j = 0; j < lastCount; j++)
                    {
                        telNoList.Add(_telNumbers[rnd.Next(0, _telNumbers.Length)].ToLower().Trim());
                    }
                }
                else
                {
                    Random rnd1 = new Random(Environment.TickCount);
                    Thread.Sleep(1000);
                    Random rnd2 = new Random(Environment.TickCount);

                    int lastCount = _telNumbersDiallingCodes.Length;

                    string number = "";

                    for (int j = 0; j < lastCount; j++)
                    {
                        number = _telNumbersDiallingCodes[rnd1.Next(0, _telNumbersDiallingCodes.Length)].ToLower().Trim();
                        number += " " + _telNumbersMainNumber[rnd2.Next(0, _telNumbersMainNumber.Length)].ToLower().Trim();
                        telNoList.Add(number);
                    }
                }

                return telNoList;
            }

            public List<string> CreateMobileTelNumberList()
            {
                List<string> mobileTelNoList = new List<string>();
                Random rnd = new Random(Environment.TickCount);
                int lastCount = _telNumbers.Length;

                for (int j = 0; j < lastCount; j++)
                {
                    mobileTelNoList.Add(_mobileNumbers[rnd.Next(0, _mobileNumbers.Length)].ToLower().Trim());
                }

                return mobileTelNoList;
            }

            public string CreateSingleEmail()
            {
                Random rnd = new Random(Environment.TickCount);
                return String.Format(_telNumbers[rnd.Next(0, _telNumbers.Length)].ToLower().Trim());
            }
        }

        public class EmailGenerator
        {
            private string[] _firstNames;
            private string[] _lastNames;
            private string[] _domains;
            private string[] _providers;

            public EmailGenerator()
            {
                LoadDefaultParameters();
            }

            public EmailGenerator(ExternalParams externalParams)
            {
                LoadDefaultParameters();
                LoadExternalParameters(externalParams);
            }

            private void LoadDefaultParameters()
            {
                _firstNames = InternalParams.FirstNames.Split(',');
                _lastNames = InternalParams.LastNames.Split(',');
                _domains = InternalParams.Domains.Split(',');
                _providers = InternalParams.EmailProviders.Split(',');
            }

            private void LoadExternalParameters(ExternalParams externalParams)
            {
                if (!string.IsNullOrEmpty(externalParams.FirstNames))
                    _firstNames = externalParams.FirstNames.Split(',');
                if (!string.IsNullOrEmpty(externalParams.LastNames)) _lastNames = externalParams.LastNames.Split(',');
                if (!string.IsNullOrEmpty(externalParams.Domains)) _domains = externalParams.Domains.Split(',');
                if (!string.IsNullOrEmpty(externalParams.EmailProviders))
                    _providers = externalParams.EmailProviders.Split(',');
            }

            public List<string> CreateEmailList()
            {
                List<string> emailList = new List<string>();
                Random rnd = new Random(Environment.TickCount);
                int lastCount = _lastNames.Length;

                for (int j = 0; j < lastCount; j++)
                {
                    string firstName = _firstNames[rnd.Next(0, _firstNames.Length)].ToLower().Trim();
                    string lastName = _lastNames[rnd.Next(0, _lastNames.Length)].ToLower().Trim();
                    string domainName = _domains[rnd.Next(0, _domains.Length)].ToLower().Trim();
                    string providerName = _providers[rnd.Next(0, _providers.Length)].ToLower().Trim();

                    emailList.Add(String.Format("{0}.{1}@{2}.{3}", firstName, lastName, providerName, domainName));
                }

                return emailList;
            }

            public string CreateSingleEmail()
            {
                Random rnd = new Random(Environment.TickCount);

                string firstName = _firstNames[rnd.Next(0, _firstNames.Length)].ToLower().Trim();
                string lastName = _lastNames[rnd.Next(0, _lastNames.Length)].ToLower().Trim();
                string domainName = _domains[rnd.Next(0, _domains.Length)].ToLower().Trim();
                string providerName = _providers[rnd.Next(0, _providers.Length)].ToLower().Trim();

                return String.Format("{0}.{1}@{2}.{3}", firstName, lastName, providerName, domainName);
            }
        }

        public class ContactGenerator
        {
            private string[] _firstNames;
            private string[] _lastNames;
            private string[] _emailProviders;
            private string[] _domains;
            private string[] _telNos;

            public ContactGenerator()
            {
                LoadDefaultParameters();
            }

            public ContactGenerator(ExternalParams externalParams)
            {
                LoadDefaultParameters();
                LoadExternalParameters(externalParams);
            }

            private void LoadDefaultParameters()
            {
                _firstNames = InternalParams.FirstNames.Split(',');
                _lastNames = InternalParams.LastNames.Split(',');
                _domains = InternalParams.Domains.Split(',');
                _emailProviders = InternalParams.EmailProviders.Split(',');
                _telNos = InternalParams.TelNos.Split(',');
            }

            private void LoadExternalParameters(ExternalParams externalParams)
            {
                if (!string.IsNullOrEmpty(externalParams.FirstNames)) _firstNames = externalParams.FirstNames.Split(',');
                if (!string.IsNullOrEmpty(externalParams.LastNames)) _lastNames = externalParams.LastNames.Split(',');
                if (!string.IsNullOrEmpty(externalParams.EmailProviders)) _emailProviders = externalParams.EmailProviders.Split(',');
                if (!string.IsNullOrEmpty(externalParams.TelNos)) _telNos = externalParams.TelNos.Split(',');
                if (!string.IsNullOrEmpty(externalParams.Domains)) _domains = externalParams.Domains.Split(',');
            }
            public List<string> CreateContacts(bool includeEmail, bool includeTelNo, bool commaSeparateName = false)
            {
                List<string> namesList = new List<string>();
                Random rnd = new Random(Environment.TickCount);
                int lastCount = 1000;

                for (int j = 0; j < lastCount; j++)
                {
                    string firstName = _firstNames[rnd.Next(0, _firstNames.Length)].Trim();
                    string lastName = _lastNames[rnd.Next(0, _lastNames.Length)].Trim();
                    var returnEntry = "";

                    if (commaSeparateName)
                    {
                        returnEntry = String.Format("{0},{1}", firstName, lastName);
                    }
                    else
                    {
                        returnEntry = String.Format("{0} {1}", firstName, lastName);
                    }

                    if (includeEmail)
                    {
                        var emailProvider = _emailProviders[rnd.Next(0, _emailProviders.Length)].Trim();
                        var domain = _domains[rnd.Next(0, _domains.Length)].Trim();
                        returnEntry += $",{firstName.ToLower().Trim()}.{lastName.ToLower().Trim()}@{emailProvider}.{domain}";
                    }

                    if (includeTelNo)
                    {
                        string telNo = _telNos[rnd.Next(0, _telNos.Length)].Trim();
                        returnEntry += $",{telNo}";
                    }

                    namesList.Add(returnEntry);
                }

                return namesList;
            }
        }

        public class NameGenerator
        {
            private string[] _firstNames;
            private string[] _lastNames;

            public NameGenerator()
            {
                LoadDefaultParameters();
            }

            public NameGenerator(ExternalParams externalParams)
            {
                LoadDefaultParameters();
                LoadExternalParameters(externalParams);
            }

            private void LoadDefaultParameters()
            {
                _firstNames = InternalParams.FirstNames.Split(',');
                _lastNames = InternalParams.LastNames.Split(',');
            }

            private void LoadExternalParameters(ExternalParams externalParams)
            {
                if (!string.IsNullOrEmpty(externalParams.FirstNames))
                    _firstNames = externalParams.FirstNames.Split(',');
                if (!string.IsNullOrEmpty(externalParams.LastNames)) _lastNames = externalParams.LastNames.Split(',');
            }

            public List<string> CreateNamesList()
            {
                List<string> namesList = new List<string>();
                Random rnd = new Random(Environment.TickCount);
                int lastCount = _lastNames.Length;

                for (int j = 0; j < lastCount; j++)
                {
                    string firstName = _firstNames[rnd.Next(0, _firstNames.Length)].Trim();
                    string lastName = _lastNames[rnd.Next(0, _lastNames.Length)].Trim();

                    namesList.Add(String.Format("{0} {1}", firstName, lastName));
                }

                return namesList;
            }

            public string CreateSingleName()
            {
                Random rnd = new Random(Environment.TickCount);

                string firstName = _firstNames[rnd.Next(0, _firstNames.Length)].Trim();
                string lastName = _lastNames[rnd.Next(0, _lastNames.Length)].Trim();

                return String.Format("{0} {1}", firstName, lastName);
            }
        }

        public class CompanyNameGenerator
        {
            private string[] _companyNames;

            public CompanyNameGenerator()
            {
                LoadDefaultParameters();
            }

            public CompanyNameGenerator(ExternalParams externalParams)
            {
                LoadDefaultParameters();
                LoadExternalParameters(externalParams);
            }

            private void LoadDefaultParameters()
            {
                _companyNames = InternalParams.CompanyNames.Split(',');
            }

            private void LoadExternalParameters(ExternalParams externalParams)
            {
                if (!string.IsNullOrEmpty(externalParams.FirstNames))
                    _companyNames = externalParams.CompanyNames.Split(',');
            }

            public List<string> CreateCompanyNamesList()
            {
                List<string> namesList = new List<string>();
                Random rnd = new Random(Environment.TickCount);

                for (int j = 0; j < 900; j++)
                {
                    string companyName = _companyNames[rnd.Next(0, _companyNames.Length)].Trim();

                    namesList.Add(String.Format("{0}", companyName));

                }

                return namesList;
            }

            public string CreateSingleCompanyName()
            {
                Random rnd = new Random(Environment.TickCount);

                string companyName = _companyNames[rnd.Next(0, _companyNames.Length)].Trim();

                return String.Format("{0}", companyName);
            }
        }

        public class AccountReferenceGenerator
        {
            public List<string> CreateAccountReference(int length = 8, int count = 1, string prefix = "",
                string suffix = "", string seperator = "")
            {
                var returnList = new List<string>();

                var allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";

                var random = new Random();
                int seed = random.Next(1, int.MaxValue);

                var chars = new char[length];
                var rnd = new Random(seed);

                for (int j = 0; j < count; j++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        chars[i] = allowedChars[rnd.Next(0, allowedChars.Length)];
                    }

                    if (returnList.Contains(new string(chars)))
                    {
                        j--;
                    }

                    else
                    {
                        returnList.Add($"{prefix}{seperator}{new string(chars)}{suffix}");
                    }
                }

                return returnList;
            }
        }

        public class AddressGenerator
        {
            private string[] _streets;
            private string[] _counties;
            private string[] _cities;
            private string[] _postCodes;
            private string[] _telNos;

            public AddressGenerator()
            {
                LoadDefaultParameters();
            }

            public AddressGenerator(ExternalParams externalParams)
            {
                LoadDefaultParameters();
                LoadExternalParameters(externalParams);
            }

            private void LoadDefaultParameters()
            {
                _streets = InternalParams.StreetNames.Split(',');
                _cities = InternalParams.Cities.Split(',');
                _counties = InternalParams.Counties.Split(',');
                _postCodes = InternalParams.PostCodes.Split(',');
            }

            private void LoadExternalParameters(ExternalParams externalParams)
            {
                if (!string.IsNullOrEmpty(externalParams.StreetNames)) _streets = externalParams.StreetNames.Split(',');
                if (!string.IsNullOrEmpty(externalParams.Cities)) _cities = externalParams.Cities.Split(',');
                if (!string.IsNullOrEmpty(externalParams.Counties)) _counties = externalParams.Counties.Split(',');
                if (!string.IsNullOrEmpty(externalParams.Postcodes)) _postCodes = externalParams.Postcodes.Split(',');
            }

            public List<string> CreateAddressList()
            {
                List<string> addressList = new List<string>();
                Random rnd = new Random(Environment.TickCount);
                int lastCount = _postCodes.Length;

                for (int j = 0; j < lastCount; j++)
                {
                    string street = _streets[rnd.Next(0, _streets.Length)].Trim();
                    string city = _cities[rnd.Next(0, _cities.Length)].Trim();
                    string county = _counties[rnd.Next(0, _counties.Length)].Trim();
                    string postCode = _postCodes[rnd.Next(0, _postCodes.Length)].Trim();

                    addressList.Add(String.Format("{0},{1},{2},{3}", street, city, county, postCode));

                }

                return addressList;
            }

            public string CreateSingleAddress()
            {
                Random rnd = new Random(Environment.TickCount);

                string street = _streets[rnd.Next(0, _streets.Length)].Trim();
                string city = _cities[rnd.Next(0, _cities.Length)].Trim();
                string county = _counties[rnd.Next(0, _counties.Length)].Trim();
                string postCode = _postCodes[rnd.Next(0, _postCodes.Length)].Trim();

                return String.Format("{0},{1},{2},{3}", street, city, county, postCode);
            }
        }

        public class WebsiteGenerator
        {
            public Dictionary<string, string> CreateWebsites(List<string> companyNames)
            {
                Random rnd = new Random(Environment.TickCount);
                Dictionary<string, string> result = new Dictionary<string, string>();
                var domainSuffixes = InternalParams.Domains.Split(',');

                foreach (var name in companyNames)
                {
                    string domainSuffix = domainSuffixes[rnd.Next(0, domainSuffixes.Length)].Trim();
                    var domain = $"{name.ToLower().Trim().Replace(" ", "").Replace("'", "")}.{domainSuffix}";

                    if (!result.ContainsKey(name))
                        result.Add(name, domain);
                }

                return result;
            }

            public string CreateWebsite(string companyName)
            {
                Random rnd = new Random(Environment.TickCount);
                Dictionary<string, string> result = new Dictionary<string, string>();
                var domainSuffixes = InternalParams.Domains.Split(',');

                string domainSuffix = domainSuffixes[rnd.Next(0, domainSuffixes.Length)].Trim();
                return $"{companyName.ToLower().Trim().Replace(" ", "").Replace("'", "")}.{domainSuffix}";
            }
        }

        public class ContactTypeGenerator
        {
            /// <summary>
            /// E.g. Customer, Lead, Contractor etc.
            /// </summary>
            /// <returns></returns>
            public List<string> GetContactTypeList(int count = 500)
            {
                var typeList = new List<string>();
                var types = InternalParams.ContactType.Split(',');

                while (typeList.Count < count)
                {
                    typeList.AddRange(types);
                }


                if (typeList.Count > count)
                    return typeList.Take(count).ToList();

                return typeList;
            }
        }
    }
}
