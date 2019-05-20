using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api.Models
{
    public class RequestTicket
    {
        public bool Result { get; set; }
        public Data Data { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Data
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string CadastralNumber { get; set; }
    }

    public abstract class Suggestion
    {
        public string value { get; set; }
        public override string ToString()
        {
            return value;
        }
    }

    public class SuggestPartyResponse
    {
        public class Suggestions : Suggestion
        {
            public PartyData data { get; set; }
        }
        public List<Suggestions> suggestionss { get; set; }
    }

    public class PartyData
    {
        public AddressData address { get; set; }
        public string branch_count { get; set; }
        public PartyBranchType branch_type { get; set; }
        public string inn { get; set; }
        public string kpp { get; set; }
        public PartyManagementData management { get; set; }
        public PartyNameData name { get; set; }
        public string ogrn { get; set; }
        public string okpo { get; set; }
        public string okved { get; set; }
        public PartyOpfData opf { get; set; }
        public PartyStateData state { get; set; }
        public PartyType type { get; set; }
    }

    public class PartyStateData
    {
        public string actuality_date { get; set; }
        public string registration_date { get; set; }
        public string liquidation_date { get; set; }
        public PartyStatus status { get; set; }
    }

    public enum PartyStatus
    {
        ACTIVE,
        LIQUIDATING,
        LIQUIDATED
    }
    public enum PartyType
    {
        LEGAL,
        INDIVIDUAL
    }
    public class PartyOpfData
    {
        public string code { get; set; }
        public string full { get; set; }
        public string @short { get; set; }
    }
    public class PartyNameData
    {
        public string full_with_opf { get; set; }
        public string short_with_opf { get; set; }
        public string latin { get; set; }
        public string full { get; set; }
        public string @short { get; set; }
    }

    public class PartyManagementData
    {
        public string name { get; set; }
        public string post { get; set; }
    }
    public enum PartyBranchType
    {
        MAIN,
        BRANCH
    }

    public class AddressData
    {
        public string result { get; set; }
        public string source { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string region_with_type { get; set; }
        public string region_type { get; set; }
        public string region_type_full { get; set; }
        public string region { get; set; }
        public string area_with_type { get; set; }
        public string area_type { get; set; }
        public string area_type_full { get; set; }
        public string area { get; set; }
        public string city_with_type { get; set; }
        public string city_type { get; set; }
        public string city_type_full { get; set; }
        public string city { get; set; }
        public string settlement_with_type { get; set; }
        public string settlement_type { get; set; }
        public string settlement_type_full { get; set; }
        public string settlement { get; set; }
        public string city_district { get; set; }
        public string street_with_type { get; set; }
        public string street_type { get; set; }
        public string street_type_full { get; set; }
        public string street { get; set; }
        public string house_type { get; set; }
        public string house_type_full { get; set; }
        public string house { get; set; }
        public string block_type { get; set; }
        public string block_type_full { get; set; }
        public string block { get; set; }
        public string flat_type { get; set; }
        public string flat_type_full { get; set; }
        public string flat { get; set; }
        public string postal_box { get; set; }
        public string fias_id { get; set; }
        public string fias_level { get; set; }
        public string kladr_id { get; set; }
        public string capital_marker { get; set; }
        public string okato { get; set; }
        public string oktmo { get; set; }
        public string tax_office { get; set; }
        public string geo_lat { get; set; }
        public string geo_lon { get; set; }
        public string qc_geo { get; set; }
    }

}
