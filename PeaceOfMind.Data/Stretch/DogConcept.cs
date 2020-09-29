using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Data
{
    public class DogConcept
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string Breed { get; set; }
        public string VetPreference { get; set; }
        public string VetPhone { get; set; }
        public bool IsVetAware { get; set; }
        public bool IfVetUnavailableUseOther { get; set; }
        public string TimeOwned { get; set; }
        public bool HasHealthInsurance { get; set; }
        public string HealthInsurance { get; set; }
        public bool CanBrushAndGroom { get; set; }
        public bool IsSpayedOrNudered { get; set; }
        public bool IsTrained { get; set; }
        public string KnownCommands { get; set; }
        public bool IsChipped { get; set; }
        public string ChipCompany { get; set; }
        public string ChipPhone { get; set; }
        public string ChipId { get; set; }
        public bool HasDigitalId { get; set; }
        public string DigitalIdCompany { get; set; }
        public string DigitalIdWebsite { get; set; }
        public string HowDogReactsWhenAbsent { get; set; }
        public string HidingPlaces { get; set; }
        public bool HasHarnessOrSpecialCollar { get; set; }
        public string DescribeHarnessOrSpecialCollar { get; set; }
        public string ReactionToChildrenAndAdultStrangers { get; set; }
        public string ReactionToOtherPets { get; set; }
        public string AnyReasonsToApproachWithCaution { get; set; }
        public string AnyContagiousIllnesse { get; set; }
        public string AnyPhysicalConditionsOrProblems { get; set; }
        public string SpecialAttentionToConditions { get; set; }
        public string AnyDislikes { get; set; }
        public WalkReaction WalkReaction { get; set; }
        public string OtherWalkReaction { get; set; }
        public string HasBittenAnyone { get; set; }
        public string AnythingToBeAwareOfWhileWalking { get; set; }
        public string LocationPermissionsInHouse { get; set; }
        public string WalkingTemperature { get; set; }
        public bool CanSameWalk { get; set; }
        public bool CanDifferentWalk { get; set; }
        public int IsResponsibilityShared { get; set; }
        public string SharedResponsibilityName { get; set; }
        public string SharedResponsibilityAddress { get; set; }
        public string SharedResponsibilityPhone { get; set; }
        public string SharedResponsibilityDetails { get; set; }
        public FeedingSchedule FeedingSchedule { get; set; }
        public string FoodBrand { get; set; }
        public bool CanHaveTreats { get; set; }
        public string TreatKind { get; set; }
        public string TreatConditions { get; set; }
        public string AnyAdditionalInfo { get; set; }

    }

    public enum Sex
    {
        Male,
        Female
    }

    public enum WalkReaction
    {
        OtherDogs,
        Cats,
        Squirrels,
        Children,
        Other
    }

    public enum FeedingSchedule
    {
        FreeFed,
        AMOnly,
        PMOnly,
        AMAndPM
    }
}
