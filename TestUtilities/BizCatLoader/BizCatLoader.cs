using CommonUtil;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestUtilities {
    public class BizCatLoader {

        #region Fields
        #region Data
        private string _tier1;
        private string _activelife;
        private string _diving;
        private string _fitness;
        private string _gym;
        private string _martialArts;
        private string _parks;
        private string _artAndEntertainment;
        private string _automotive;
        private string _beautyAndSpas;
        private string _hairRemoval;
        private string _salons;
        private string _education;
        private string _specialtySchools;
        private string _tastingClasses;
        private string _eventPlanning;
        private string _financialServices;
        private string _insurance;
        private string _food;
        private string _specialtyFood;
        private string _healthAndMedical;
        private string _counselingMentalHealth;
        private string _dentist;
        private string _diagnostics;
        private string _doctor;
        private string _homeServices;
        private string _hotelAndTravel;
        private string _tours;
        private string _transportation;
        private string _travelService;
        private string _localServices;
        private string _funeralServices;
        private string _itServices;
        private string _laundry;
        private string _music;
        private string _massMedia;
        private string _nightLife;
        private string _bars;
        private string _pets;
        private string _petService;
        private string _petStore;
        private string _professionalService;
        private string _lawPractice;
        private string _legalService;
        private string _publicService;
        private string _realEstate;
        private string _realEstateService;
        private string _restaurant;
        private string _caribbean;
        private string _chinese;
        private string _japanese;
        private string _shopping;
        private string _fashion;
        private string _artsCrafts;
        private string _books;
        private string _homeGarden;
        private string _sportingGoods;

        #endregion (Data)


        // NEXT IS EDUCATION
        private bool _update = true;
        private string _lookupName = "BusinessCategory";
        private List<BizCat> _bizCats = new List<BizCat>();
        #endregion (Fields)

        #region Constructor
        public BizCatLoader() {
            InitializeData();
        }
        #endregion (Constructor)

        public void LoadBizCats() {
            string[] sTier1Array = ConvertListToArray(_tier1);

            foreach (string s in sTier1Array) {
                BizCats.Add(new BizCat(s.Trim()));
            }
            foreach(BizCat oCat in BizCats) {
                LoadChildren(oCat);
            }

        }
        public void SaveBizCats() {
            foreach (BizCat oCat in BizCats) {
                if (!string.IsNullOrEmpty(oCat.Name)) {
                    oCat.Save(1, _update);
                }
            }
        }
        private void LoadChildren(BizCat toCat) {
            string sSubCategoryList = GetSubCategories(toCat);
            if (!string.IsNullOrEmpty(sSubCategoryList)) {
                LoadList(sSubCategoryList, toCat);
            }
        }
        private void LoadList(string tsCategories, BizCat toParentCat) {
            BizCat oChildCat = null;
            string[] sCategoryArray = ConvertListToArray(tsCategories);
            foreach (string s in sCategoryArray) {
                oChildCat = new BizCat(s, toParentCat);
                //toParentCat.Children.Add(new BizCat(s.Trim()));
                LoadChildren(oChildCat);
            }
        }
        private string[] ConvertListToArray(string tsStringList) {
            return tsStringList.Split("\r\n");
        }

        private string GetSubCategories(BizCat toCat) {
            string sReturn = string.Empty;
            switch(toCat.Constant){
                case "BUSINESSCATEGORY->ACTIVELIFE":
                    sReturn = _activelife;
                    break;
                case "BUSINESSCATEGORY->ACTIVELIFE->DIVING":
                    sReturn = _diving;
                    break;
                case "BUSINESSCATEGORY->ACTIVELIFE->FITNESS&INSTRUCTION":
                    sReturn = _fitness;
                    break;
                case "BUSINESSCATEGORY->ACTIVELIFE->FITNESS&INSTRUCTION->GYM":
                    sReturn = _gym;
                    break;
                case "BUSINESSCATEGORY->ACTIVELIFE->FITNESS&INSTRUCTION->MARTIALARTS":
                    sReturn = _martialArts;
                    break;
                case "BUSINESSCATEGORY->ACTIVELIFE->PARKS":
                    sReturn = _parks;
                    break;
                case "BUSINESSCATEGORY->ARTS&ENTERTAINMENT":
                    sReturn = _artAndEntertainment;
                    break;
                case "BUSINESSCATEGORY->AUTOMOTIVE":
                    sReturn = _automotive;
                    break;
                case "BUSINESSCATEGORY->BEAUTY&SPAS":
                    sReturn = _beautyAndSpas;
                    break;
                case "BUSINESSCATEGORY->BEAUTY&SPAS->HAIRREMOVAL":
                    sReturn = _beautyAndSpas;
                    break;
                case "BUSINESSCATEGORY->BEAUTY&SPAS->HAIRSALONS":
                    sReturn = _salons;
                    break;
                // Education
                case "BUSINESSCATEGORY->EDUCATION":
                    sReturn = _education;
                    break;
                case "BUSINESSCATEGORY->EDUCATION->SPECIALTYSCHOOLS":
                    sReturn = _specialtySchools;
                    break;
                case "BUSINESSCATEGORY->EDUCATION->TASTINGCLASSES":
                    sReturn = _tastingClasses;
                    break;
                case "BUSINESSCATEGORY->EVENTPLANNING&SERVICES":
                    sReturn = _eventPlanning;
                    break;
                case "BUSINESSCATEGORY->FINANCIALSERVICES":
                    sReturn = _financialServices;
                    break;
                case "BUSINESSCATEGORY->FINANCIALSERVICES->INSURANCE":
                    sReturn = _insurance;
                    break;
                case "BUSINESSCATEGORY->FOOD":
                    sReturn = _food;
                    break;
                case "BUSINESSCATEGORY->FOOD=>SPECIALTYFOOD":
                    sReturn = _specialtyFood;
                    break;
                    // Health & Medical
                case "BUSINESSCATEGORY->HEALTH&MEDICAL":
                    sReturn = _healthAndMedical;
                    break;
                case "BUSINESSCATEGORY->HEALTH&MEDICAL->COUNSELING&MENTALHEALTH":
                    sReturn = _counselingMentalHealth;
                    break;
                case "BUSINESSCATEGORY->HEALTH&MEDICAL->DENTIST":
                    sReturn = _dentist;
                    break;
                case "BUSINESSCATEGORY->HEALTH&MEDICAL->DIAGNOSTICSERVICE":
                    sReturn = _diagnostics;
                    break;
                case "BUSINESSCATEGORY->HEALTH&MEDICAL->DOCTOR":
                    sReturn = _doctor;
                    break;
                case "BUSINESSCATEGORY->HOMESERVICE":
                    sReturn = _homeServices;
                    break;
                case "BUSINESSCATEGORY->HOTEL&TRAVEL":
                    sReturn = _hotelAndTravel;
                    break;
                case "BUSINESSCATEGORY->HOTEL&TRAVEL->TOURS":
                    sReturn = _tours;
                    break;
                case "BUSINESSCATEGORY->HOTEL&TRAVEL->TRANSPORTATION":
                    sReturn = _transportation;
                    break;
                case "BUSINESSCATEGORY->HOTEL&TRAVEL->TRAVELSERVICE":
                    sReturn = _travelService;
                    break;
                case "BUSINESSCATEGORY->LOCALSERVICE":
                    sReturn = _localServices;
                    break;
                case "BUSINESSCATEGORY->LOCALSERVICES->FUNERALSERVICES&CEMETARIES":
                    sReturn = _funeralServices;
                    break;
                case "BUSINESSCATEGORY->LOCALSERVICES->ITSERVICES&COMPUTERREPAIR":
                    sReturn = _itServices;
                    break;
                case "BUSINESSCATEGORY->LOCALSERVICES->LAUNDRYSERVICECOMPUTERREPAIR":
                    sReturn = _laundry;
                    break;
                case "BUSINESSCATEGORY->LOCALSERVICES->MUSICALINSTRUMENTSERVICE":
                    sReturn = _laundry;
                    break;
                case "BUSINESSCATEGORY->MASSMEDIA":
                    sReturn = _massMedia;
                    break;
                case "BUSINESSCATEGORY->NIGHTLIFE":
                    sReturn = _nightLife;
                    break;
                case "BUSINESSCATEGORY->NIGHTLIFE->BAR":
                    sReturn = _bars;
                    break;
                case "BUSINESSCATEGORY->PETS":
                    sReturn = _pets;
                    break;
                case "BUSINESSCATEGORY->PETS-PETSERVICE":
                    sReturn = _petService;
                    break;
                case "BUSINESSCATEGORY->PETS->PETSTORE":
                    sReturn = _petStore;
                    break;
                case "BUSINESSCATEGORY->PROFESSIONALSERVICE":
                    sReturn = _professionalService;
                    break;
                case "BUSINESSCATEGORY->PROFESSIONALSERVICE-LAWPRACTICE":
                    sReturn = _lawPractice;
                    break;
                case "BUSINESSCATEGORY->PROFESSIONALSERVICE->LEGALSERVICE":
                    sReturn = _legalService;
                    break;
                case "BUSINESSCATEGORY->PUBLICSERVICE":
                    sReturn = _publicService;
                    break;
                case "BUSINESSCATEGORY->REALESTATE":
                    sReturn = _realEstate;
                    break;
                case "BUSINESSCATEGORY->REALESTATE->REALESTATESERVICE":
                    sReturn = _realEstateService;
                    break;
                case "BUSINESSCATEGORY->RESTAURANT":
                    sReturn = _restaurant;
                    break;
                case "BUSINESSCATEGORY->RESTAURANT->CARIBBEAN":
                    sReturn = _caribbean;
                    break;
                case "BUSINESSCATEGORY->RESTAURANT->CHINESE":
                    sReturn = _chinese;
                    break;
                case "BUSINESSCATEGORY->RESTAURANT->JAPANESE":
                    sReturn = _japanese;
                    break;
                case "BUSINESSCATEGORY->SHOPPING":
                    sReturn = _shopping;
                    break;
                case "BUSINESSCATEGORY->SHOPPING->ARTS&CRAFTS":
                    sReturn = _artsCrafts;
                    break;
                case "BUSINESSCATEGORY->SHOPPING->BOOKS,MAGS,MUSIC&VIDEO":
                    sReturn = _books;
                    break;
                case "BUSINESSCATEGORY->SHOPPING->FASHION":
                    sReturn = _fashion;
                    break;
                case "BUSINESSCATEGORY->SHOPPING->HOME&GARDEN":
                    sReturn = _homeGarden;
                    break;
                case "BUSINESSCATEGORY->SHOPPING->SPORTINGGOODS":
                    sReturn = _sportingGoods;
                    break;

                //default:
                //    throw new Exception($"There is no Case statement to catch [{toCat.Constant}] as a Constant.  See line 170(ish) in BizCatLoader.");
                //    break;
            }

            Debug.WriteLine(toCat.Constant);

            return sReturn;
        }

        #region Initialize Data
        private void InitializeData() {
            #region Tier One List
            _tier1 = @"Active Life
                Arts & Entertainment
                Automotive
                Beauty & Spas
                Education
                Event Planning & Services
                Financial Services
                Food
                Health & Medical
                Home Service
                Hotels & Travel
                Local Flavor
                Local Service
                Mass Media
                Nightlife
                Pets
                Professional Service
                Public Service
                Real Estate
                Restaurant
                Shopping
                ";
            #endregion (Tier One List)

            #region ActiveLife
            #region PrimaryList
            _activelife = @"ATV Rentals/Tours
                Airsoft
                Amateur Sports Teams
                Amusement Parks
                Aquariums
                Archery
                Axe Throwing
                Badminton
                Baseball Fields
                Basketball Courts
                Batting Cages
                Beach Equipment Rentals
                Beaches
                Bike Parking
                Bike Rentals
                Boating
                Bobsledding
                Bocce Ball
                Bowling
                Bubble Soccer
                Bungee Jumping
                Canyoneering
                Carousels
                Challenge Courses
                Climbing
                Dart Arenas
                Day Camps
                Disc Golf
                Diving
                Escape Games
                Fencing Clubs
                Fishing
                Fitness & Instruction
                Flyboarding
                Go Karts
                Golf 
                Gun/Rifle Ranges
                Gymnastics
                Hang Gliding
                Hiking
                Horse Racing
                Horseback Riding
                Hot Air Balloons
                Indoor Playcentre
                Jet Skis
                Kids Activities
                Kiteboarding
                Lakes
                Laser Tag
                Mini Golf
                Mountain Biking
                Nudist
                Paddleboarding
                Paintball
                Paragliding
                Parasailing
                Parks
                Pickleball
                Playgrounds
                Races & Competitions
                Racing Experience
                Rafting/Kayaking
                Recreation Centers
                Rock Climbing
                Sailing
                Scavenger Hunts
                Scooter Rentals
                Senior Centers
                Skating Rinks
                Skydiving
                Sledding
                Snorkeling
                Soccer
                Sports Clubs
                Squash
                Summer Camps
                Surfing
                Swimming Pools
                Tennis
                Trampoline Parks
                Tubing
                Water Parks
                Wildlife Hunting Ranges
                Ziplining
                Zoos";
            #endregion (Primary List)

            #region Diving
            _diving = @"Free Diving
                Scuba Diving";
            #endregion (Diving)

            #region Fitness
            _fitness = @"Aerial Fitness
                Barre Classes
                Boot Camps
                Boxing
                Cardio Classes
                Cycling Classes
                Dance Studios
                Golf Lessons
                Gym
                Martial Arts
                Meditation Centers
                Pilates
                Qi Gong
                Self-defense Classes
                Swimming Lessons/Schools
                Tai Chi
                Trainers
                Yoga";


            #region Gym
            _gym = @"Circuit Training
                Interval Training";
            #endregion (Gym)

            #region Martial Arts
            _martialArts = @"Brazilian Jiu-jitsu
                Chinese Martial Arts
                Karate
                Kickboxing
                Muay Thai
                Taekwondo";
            #endregion (Martial Arts)

            #endregion (Fitness)

            #region Parks
            _parks = @"Dog Parks
                Skate Parks";
            #endregion (Parks)

            #endregion (ActiveLife)

            #region Arts & Entertainment
            _artAndEntertainment = @"Arcades
                Art Galleries
                Bingo Halls
                Botanical Gardens
                Cabaret
                Casinos
                Cinema
                Country Clubs
                Cultural Center
                Entertainment
                Festivals
                Haunted Houses
                Jazz & Blues
                LAN Centers
                Makerspaces
                Museums
                Music Venues
                Observatories
                Opera & Ballet
                Paint & Sip
                Performing Arts
                Planetarium
                Professional Sports Teams
                Race Tracks
                Rodeo
                Social Clubs
                Sports Betting
                Stadiums & Arenas
                Studio Taping
                Ticket Sales
                Virtual Reality Centers
                Wineries
                Wine Tasting Rooms
                ";
            #endregion (Arts & Entertainment)

            #region Automotive

            #region PrimaryList
            _automotive = @"Aircraft Dealers
                Aircraft Repairs
                Auto Customization
                Auto Detailing
                Auto Loan Providers
                Auto Parts & Supplies
                Auto Repair
                Auto Security
                Auto Upholstery
                Aviation Services
                Boat Dealers
                Boat Parts & Supplies
                Body Shops
                Car Auctions
                Car Brokers
                Car Buyers
                Car Dealers
                Car Inspectors
                Car Share Services
                Car Stereo Installation
                Car Wash
                Commercial Truck Dealers
                Commercial Truck Repair
                EV Charging Stations
                Fuel Docks
                Gas Stations
                Golf Cart Dealers
                Hybrid Car Repair
                Interlock Systems
                Marinas (marinas)
                Mobile Dent Repair
                Mobility Equipment Sales & Services
                Motorcycle Dealers
                Motorcycle Repair
                Motorsport Vehicle Dealers
                Motorsport Vehicle Repairs
                Oil Change Stations
                Parking
                RV Dealers
                RV Repair
                Registration Services
                Roadside Assistance
                Service Stations
                Smog Check Stations
                Tires
                Towing
                Trailer Dealers
                Trailer Rental
                Trailer Repair
                Transmission Repair
                Truck Rental
                Used Car Dealers
                Vehicle Shipping
                Vehicle Wraps
                Wheel & Rim Repair
                Window Tinting
                Windshield Installation & Repair
                ";

            #endregion (PrimaryList)

            #endregion (Automotive)

            #region Beauty & Spas

            #region PrimaryList
            _beautyAndSpas = @"Acne Treatment
                Barbers
                Cosmetics & Beauty Supply
                Day Spas
                Eyebrow Services
                Eyelash Service
                Hair Extensions
                Hair Loss Centers
                Hair Removal
                Hair Salons
                Hot Springs
                Makeup Artists
                Massage
                Medical Spas
                Nail Salons
                Perfume
                Permanent Makeup
                Piercing
                Skin Care
                Tanning
                Tattoo
                Teeth Whitening";
            #endregion (PrimaryList)

            #region Hair Removal
            _hairRemoval = @"Laser Hair Removal
                Sugaring
                Threading Services
                Waxing
                ";
            #endregion (Hair Removal)

            #region Hair Salons
            _salons = @"Blow Dry/Out Services
                Hair Extensions
                Hair Stylists
                Kids Hair Salons
                Men’s Hair Salons";
            #endregion (Hair Salons)

            #endregion (Beauty & Spas)

            #region Education
            #region Primary List
            _education = @"Adult Education
                Art Classes
                College Counseling
                Colleges & Universities
                Educational Services
                Elementary Schools
                Middle Schools & High Schools
                Montessori Schools
                Preschools
                Private Schools
                Private Tutors
                Religious Schools
                Special Education
                Specialty Schools
                Tasting Classes
                Test Preparation
                Tutoring Centers
                Waldorf Schools";
            #endregion (Primary List)


            #region Specialty Schools
            _specialtySchools = @"Art Schools
                Bartending Schools
                CPR Classes
                Cheerleading
                Childbirth Education
                Cooking Schools
                Cosmetology Schools
                DUI Schools
                Dance Schools
                Drama Schools
                Driving Schools
                Firearm Training
                First Aid Classes
                Flight Instruction
                Food Safety Training
                Language Schools
                Massage Schools
                Nursing Schools
                Parenting Classes
                Photography Classes
                Pole Dancing Classes
                Ski Schools
                Speech Training
                Surf Schools
                Swimming Lessons/Schools
                Traffic Schools
                Vocational & Technical School";
            #endregion (Specialty Schools)


            #region Tasting Classes
            _tastingClasses = @"Cheese Tasting Classes
                Wine Tasting Classes";
            #endregion (Tasting Classes)

            #endregion (Education)

            #region Event Planning & Services
            #region Primary List
            _eventPlanning = @"Balloon Services
                Bartenders
                Boat Charters
                Cards & Stationery
                Caricatures
                Caterers
                Clowns
                DJs
                Face Painting
                Floral Designers
                Game Truck Rental
                Golf Cart Rentals
                Henna Artists
                Hotels
                Magicians
                Mohels
                Musicians
                Officiants
                Party & Event Planning
                Party Bike Rentals
                Party Bus Rentals
                Party Characters
                Party Equipment Rentals
                Party Supplies
                Personal Chefs
                Photo Booth Rentals
                Photographers
                Silent Disco
                Sommelier Services
                Team Building Activities
                Trivia Hosts
                Valet Services
                Venues & Event Spaces
                Videographers
                Wedding Chapels
                Wedding Planning";
            #endregion (Primary List)
            #endregion (Event Planning & Services)

            #region Financial Services
            #region Primary List
            _financialServices = @"Banks & Credit Unions
                Business Financing
                Check Cashing/Pay-day Loans
                Currency Exchange
                Debt Relief Services
                Financial Advising
                Installment Loans
                Insurance
                Investing
                Mortgage Lenders
                Tax Services
                Title Loans";
            #endregion (Primary List)

            #region Insurance
            _insurance = @"Auto Insurance
                Home & Rental Insurance
                Life Insurance";

            #endregion (Insurance)

            #endregion (Financial Services)

            #region Food
            #region Primary List
            _food = @"Acai Bowls
                Bagels
                Bakeries
                Beer, Wine & Spirits
                Beverage Store
                Breweries
                Brewpubs
                Bubble Tea
                Butcher
                CSA
                Chimney Cakes
                Cideries
                Coffee & Tea
                Coffee Roasteries
                Convenience Stores
                Cupcakes
                Custom Cakes
                Desserts
                Distilleries
                Do-It-Yourself Food
                Donuts
                Empanadas
                Farmers Market
                Food Delivery Services
                Food Trucks
                Gelato
                Grocery
                Honey
                Ice Cream & Frozen Yogurt
                Imported Food
                International Grocery
                Internet Cafes
                Juice Bars & Smoothies
                Kombucha
                Meaderies
                Organic Stores
                Patisserie/Cake Shop
                Piadina
                Poke
                Pretzels
                Shaved Ice
                Shaved Snow
                Smokehouse
                Specialty Food
                Street Vendors
                Tea Rooms
                Water Stores
                Winery
                Wine Tasting Room";
            #endregion (Primary List)

            #region Specialty Food
            _specialtyFood = @"Candy Stores
                Cheese Shops
                Chocolatiers & Shops
                Fruits & Veggies
                Health Markets
                Herbs & Spices
                Macarons
                Meat Shops
                Olive Oil
                Pasta Shops
                Popcorn Shops
                Seafood Markets";
            #endregion (Specialty Food)

            #endregion (Food)

            #region Health & Medical
            #region Primary List
            _healthAndMedical = @"Acupuncture
                Alternative Medicine
                Animal Assisted Therapy
                Assisted Living Facility
                Ayurveda
                Behavior Analysts
                Blood & Plasma Donation Center
                Body Contouring
                Cannabis Clinics
                Cannabis Collective
                Chiropractors
                Colonics
                Concierge Medicine
                Counseling & Mental Health
                Crisis Pregnancy Center
                Cryotherapy
                Dental Hygienists
                Dentists
                Diagnostic Services
                Dialysis Clinics
                Dietitians
                Doctors
                Emergency Rooms
                Float Spa
                Habilitative Services
                Halfway Houses
                Halotherapy
                Health Coach
                Health Insurance Offices
                Hearing Aid Providers
                Herbal Shops
                Home Health Care
                Hospice
                Hospitals
                Hydrotherapy
                Hypnosis/Hypnotherapy
                IV Hydration
                Lactation Services
                Laser Eye Surgery/Lasik
                Lice Services
                Massage Therapy
                Medical Cannabis Referrals
                Medical Centers
                Medical Spas
                Medical Transportation
                Memory Care
                Midwives
                Nurse Practitioner
                Nutritionists
                Occupational Therapy
                Optometrists
                Organ & Tissue Donor Services
                Orthotics
                Oxygen Bars
                Personal Care Services
                Pharmacy
                Physical Therapy
                Placenta Encapsulations
                Prenatal/Perinatal Care
                Prosthetics
                Prosthodontists
                Reflexology
                Rehabilitation Center
                Reiki
                Reproductive Health Services
                Retirement Homes
                Saunas
                Skilled Nursing
                Sleep Specialists
                Speech Therapists
                Sperm Clinic
                Traditional Chinese Medicine
                Ultrasound Imaging Centers
                Urgent Care
                Weight Loss Centers
                Home Services";

            #endregion (Primary List)

            #region Counseling
            _counselingMentalHealth = @"Psychologists
                Sex Therapists
                Sports Psychologists";
            #endregion (Counseling)

            #region Dentist
            _dentist = @"Cosmetic Dentists
                Endodontists
                General Dentistry
                Oral Surgeons
                Orthodontists
                Pediatric Dentists
                Periodontists";
            #endregion (Dentist)

            #region Diagnostics
            _diagnostics = @"Diagnostic Imaging
                Laboratory Testing";
            #endregion (Diagnostics)

            #region Doctor
            _doctor = @"Addiction Medicine
                Allergists
                Anesthesiologists
                Audiologist
                Cardiologists
                Cosmetic Surgeons
                Dermatologists
                Ear Nose & Throat
                Emergency Medicine
                Endocrinologists
                Family Practice
                Fertility
                Gastroenterologist
                Geneticists
                Gerontologists
                Hepatologists
                Hospitalists
                Immunodermatologists
                Infectious Disease Specialists
                Internal Medicine
                Naturopathic/Holistic
                Nephrologists
                Neurologist
                Neuropathologists
                Neurotologists
                Obstetricians & Gynecologists
                Oncologist
                Ophthalmologists
                Orthopedists
                Osteopathic Physicians
                Otologists
                Pain Management
                Pathologists
                Pediatricians
                Phlebologists
                Plastic Surgeons
                Podiatrists
                Preventive Medicine
                Proctologists
                Psychiatrists
                Pulmonologist
                Radiologists
                Rheumatologists
                Spine Surgeons
                Sports Medicine
                Surgeons
                Tattoo Removal
                Toxicologists
                Undersea/Hyperbaric Medicine
                Urologists
                Vascular Medicine";
            #endregion (Doctor)

            #endregion (Health & Medical)

            #region Home Service

            #region Primary List
            _homeServices = @"Artificial Turf
                Building Supplies
                Cabinetry
                Carpenters
                Carpet Installation
                Carpeting
                Childproofing
                Chimney Sweeps
                Contractors
                Countertop Installation
                Damage Restoration
                Decks & Railing
                Demolition Services
                Door Sales/Installation
                Drywall Installation & Repair
                Electricians
                Excavation Services
                Fences & Gates
                Fire Protection Services
                Fireplace Services
                Firewood
                Flooring
                Foundation Repair
                Furniture Assembly
                Garage Door Services
                Gardeners
                Glass & Mirrors
                Grout Services
                Gutter Services
                Handyman
                Heating & Air Conditioning/HVAC
                Holiday Decorating Services
                Home Automation
                Home Cleaning
                Home Energy Auditors
                Home Inspectors
                Home Network Installation
                Home Organization
                Home Theatre Installation
                Home Window Tinting
                House Sitters
                Insulation Installation
                Interior Design
                Internet Service Providers
                Irrigation
                Keys & Locksmiths
                Landscape Architects
                Landscaping
                Lawn Services
                Lighting Fixtures & Equipment
                Masonry/Concrete
                Mobile Home Repair
                Movers
                Packing Services
                Painters
                Patio Coverings
                Plumbing
                Backflow Services
                Pool & Hot Tub Service
                Pool Cleaners
                Pressure Washers
                Refinishing Services
                Roof Inspectors
                Roofing
                Sauna Installation & Repair
                Security Systems
                Shades & Blinds
                Shutters
                Siding
                Solar Installation
                Solar Panel Cleaning
                Structural Engineers
                Stucco Services
                Television Service Providers
                Tiling
                Tree Services
                Wallpapering
                Water Heater Installation/Repair
                Water Purification Services
                Waterproofing
                Window Washing
                Windows Installation";
            #endregion (Primary List)

            #endregion (Home Service)

            #region Hotel & Travel

            #region Primary List
            _hotelAndTravel = @"Bed & Breakfast
                Campgrounds
                Car Rental
                Guest Houses
                Health Retreats
                Hostels
                Hotels
                Motorcycle Rental
                RV Parks
                RV Rental
                Resorts
                Ski Resorts
                Tours
                Transportation
                Travel Service
                Vacation Rental Agent
                Vacation Rentals";
            #endregion (Primary List)

            #region Tours
            _tours = @"Aerial Tours
                Architectural Tours
                Art Tours
                Beer Tours
                Bike tours
                Boat Tours
                Bus Tours
                Food Tours
                Historical Tours
                Scooter Tours
                Walking Tours
                Whale Watching Tours
                Wine Tours";
            #endregion (Tours)

            #region Transportation
            _transportation = @"Airlines
                Airport Shuttles
                Bike Sharing
                Bus Stations
                Buses
                Cable Cars
                Ferries
                Limos
                Metro Stations
                Pedicabs
                Private Jet Charter
                Public Transportation
                Taxis
                Town Car Service
                Trains";

            #endregion (Transportation)

            #region Travel Service
            _travelService = @"Luggage Storage
                Passport & Visa Services
                Travel Agents
                Visitor Centers";
            #endregion (Travel Service)

            #endregion (Hotel & Travel)

            #region Local Services

            #region Primary List
            _localServices = @"3D Printing
                Adoption Services
                Air Duct Cleaning
                Appliances & Repair
                Appraisal Services
                Art Installation
                Art Restoration
                Awnings
                Bail Bondsmen
                Bike Repair/Maintenance
                Biohazard Cleanup
                Bookbinding
                Bus Rental
                Calligraphy
                Carpet Cleaning
                Carpet Dyeing
                Child Care & Day Care
                Clock Repair
                Community Book Box
                Community Gardens
                Community Service/Non-Profit
                Couriers & Delivery Services
                Crane Services
                Donation Center
                Elder Care Planning
                Electronics Repair
                Elevator Services
                Engraving
                Environmental Abatement
                Environmental Testing
                Farm Equipment Repair
                Fingerprinting
                Funeral Services & Cemeteries
                Furniture Rental
                Furniture Repair
                Furniture Reupholstery
                Generator Installation/Repair
                Grill Services
                Gunsmith
                Hazardous Waste Disposal
                Hydro-jetting
                IT Services & Computer Repair
                Ice Delivery
                Jewelry Repair
                Junk Removal & Hauling
                Junkyards
                Knife Sharpening
                Laundry Service
                Machine & Tool Rental
                Machine Shops
                Mailbox Centers
                Metal Detector Service
                Metal Fabricators
                Misting System Service
                Musical Instrument Service
                Nanny Services
                Notaries
                Outdoor Power Equipment Service
                Pest Control
                Portable Toilet Service
                Powder Coating
                Printing Services
                Propane
                Recording & Rehearsal Studios
                Recycling Center
                Sandblasting
                Screen Printing
                Screen Printing/T-Shirt Printing
                Self Storage
                Septic Services
                Sewing & Alterations
                Shipping Centers
                Shoe Repair
                Shoe Shine
                Snow Removal
                Snuggle Services
                Stonemasons
                TV Mounting
                Watch Repair
                Water Delivery
                Well Drilling
                Wildlife Control";
            #endregion (Primary List)

            #region Funeral Services & Mortuaries
            _funeralServices = @"Cremation Services
                Mortuary Services";
            #endregion (Funeral Services & Mortuaries)

            #region IT SERVICES
            _itServices = @"Data Recovery
                Mobile Phone Repair
                Telecommunications";
            #endregion (IT SERVICES)

            #region Laundry Services
            _laundry = @"Dry Cleaning
                Laundromat";
            #endregion (Laundry Services)
            
            #region Musical Instrument
            _music = @"Guitar Stores
                Piano Services
                Piano Stores
                Vocal Coach";
            #endregion (Musical Instrument)

            #endregion (Local Services)

            #region Mass Media

            #region Primary List
            _massMedia = @"Print Media
                Radio Stations
                Television Stations";
            #endregion (Primary List)

            #endregion (Mass Media)

            #region Night Life

            #region Primary List
            _nightLife = @"Bar
                Beer Gardens
                Club Crawl
                Comedy Clubs
                Country Dance Halls
                Dance Clubs
                Jazz & Blues
                Karaoke
                Music Venue
                Piano Bar
                Pool Halls";
            #endregion (Primary List)

            #region Bar
            _bars = @"Airport Lounges
                Beer Bar
                Champagne Bars
                Cigar Bars
                Cocktail Bars
                Dive Bars
                Drive-Thru Bars
                Gay Bars
                Hookah Bars
                Irish Pub
                Lounges
                Pubs
                Speakeasies
                Sports Bars
                Tiki Bars
                Vermouth Bars
                Whiskey Bars
                Wine Bars";
            #endregion (Bar)

            #endregion (Night Life)

            #region Pets

            #region Primary List
            _pets = @"Animal Shelter
                Horse Boarding
                Pet Adoption
                Pet Service
                Pet Store
                Veterinarian";
            #endregion (Primary List)

            #region Pet Services
            _petService = @"Animal Physical Therapy
                Aquarium Services
                Dog Walkers
                Emergency Pet Hospital
                Farriers
                Holistic Animal Care
                Pet Breeders
                Pet Cremation Services
                Pet Groomers
                Pet Hospice
                Pet Insurance
                Pet Photography
                Pet Sitting
                Pet Boarding
                Pet Training
                Pet Transportation
                Pet Waste Removal";
            #endregion (Pet Services)

            #region Pet Store
            _petStore = @"Bird Shops
                Local Fish Stores
                Reptile Shops";
            #endregion (Pet Store)

            #endregion (Pets)

            #region Professional Services

            #region Primary List
            _professionalService = @"Accountant
                Advertising
                Architects
                Art Consultants
                Billing Service
                Boat Repair
                Bookkeepers
                Business Consulting
                Career Counseling
                Commissioned Artist
                Customs Brokers
                Digitizing Service
                Duplication Service
                Editorial Service
                Employment Agency
                Graphic Design
                Indoor Landscaping
                Internet Service Provider
                Law Practice
                Legal Service
                Life Coach
                Marketing
                Matchmakers
                Mediators
                Music Production Service
                Office Cleaning
                Patent Law
                Payroll Services
                Personal Assistants
                Private Investigation
                Product Design
                Public Adjusters
                Public Relations
                Security Service
                Shredding Service
                Signmaking
                Software Development
                Talent Agency
                Taxidermy
                Tenant and Eviction Law
                Translation Services
                Video/Film Production
                Web Design
                Wholesaler";
            #endregion (Primary List)

            #region Law Practice
            _lawPractice = @"Bankruptcy Law
                Business Law
                Consumer Law
                Contract Law
                Criminal Defense Law
                DUI Law
                Disability Law
                Divorce & Family Law
                Elder Law
                Employment Law
                Entertainment Law
                Estate Planning Law";
            #endregion (Law Practice)

            #region Legal Services
            _legalService = @"Court Reporters
                Process Servers";
            #endregion (Legal Services)

            #endregion (Professional Services)

            #region Public Service

            #region Primary List
            _publicService = @"Community Center
                Privatized Jail Or Prison
                Landmark Or Historical Venue
                Library
                Security Service
                Town Hall";
            #endregion (Primary List)

            #endregion (Public Service)

            #region Real Estate

            #region Primary List
            _realEstate = @"Apartments
                Art Space Rentals
                Estate Liquidator
                Home Staging
                Homeowner Association
                Kitchen Incubator
                Mobile Home Dealership
                Mobile Home Park
                Mortgage Broker
                Property Management
                Real Estate Service";

            #endregion (Region Name)

            #region Real Estate Service
            _realEstateService = @"Land Surveying
                Real Estate Photography
                Realty Office";
            #endregion (Real Estate Service)

            #endregion (Real Estate)

            #region Restaurants

            #region Primary List
            _restaurant = @"Afghan
                African
                American (New)
                American (Traditional)
                Arabian
                Argentine
                Armenian
                Asian Fusion
                Australian
                Austrian
                Bangladeshi
                Barbeque
                Basque
                Belgian
                Brassery
                Brazilian
                Breakfast & Brunch
                British
                Buffets
                Bulgarian
                Burgers
                Burmese
                Cafes
                Cafeteria
                Cajun/Creole
                Cambodian
                Caribbean
                Catalan
                Cheesesteaks
                Chicken Shop
                Chicken Wings
                Chinese
                Comfort Food
                Creperies
                Cuban
                Czech
                Delis
                Diners
                Dinner Theater
                Eritrean
                Ethiopian
                Fast Food
                Filipino
                Fish & Chips
                Fondue
                Food Court
                Food Stand
                French
                Gastropub
                Georgian
                German
                Gluten-Free
                Greek
                Guamanian
                Halal
                Hawaiian
                Himalayan/Nepalese
                Honduran
                Hong Kong Style Cafe
                Hot Dogs
                Hot Pot
                Hungarian
                Iberian
                Indian
                Indonesian
                Irish
                Italian
                Japanese
                Kebab
                Korean
                Kosher
                Laotian
                Latin American
                Live/Raw Food
                Malaysian
                Mediterranean
                Mexican
                Middle Eastern
                Modern European
                Mongolian
                Moroccan
                New Mexican Cuisine
                Nicaraguan
                Noodles
                Pakistani
                Pan Asia
                Persian/Iranian
                Peruvian
                Pizza
                Polish
                Polynesian
                Portuguese
                Poutineries
                Russian
                Salad
                Sandwiches
                Scandinavian
                Scottish
                Seafood
                Singaporean
                Slovakian
                Somali
                Soul Food
                Soup
                Southern
                Spanish
                Sri Lankan
                Steakhouses
                Supper Club
                Sushi Bars
                Syrian
                Taiwanese
                Tapas Bars
                Tapas/Small Plate
                Tex-Mex
                Thai
                Turkish
                Ukrainian
                Uzbek
                Vegan
                Vegetarian
                Vietnamese
                Waffles
                Wraps";
            #endregion (Primary List)

            #region Caribbean
            _caribbean = @"Dominican
                Haitian
                Puerto Rican
                Trinidadian";
            #endregion (Caribbean)

            #region Chinese
            _chinese = @"Cantonese
                Dim Sum
                Hainan
                Shanghainese
                Szechuan";
            #endregion (Chinese)

            #region Japanese
            _japanese = @"Conveyor Belt Sushi
                Izakaya
                Japanese Curry
                Ramen
                Teppanyaki";
            #endregion (Japanese)

            #endregion (Restaurants)

            #region Shopping

            #region PrimaryList
            _shopping = @"Antiques
                Art Galleries
                Arts & Crafts
                Auction Houses
                Baby Gear & Furniture
                Battery Stores
                Bespoke Clothing
                Books, Mags, Music & Video
                Auction Houses
                Baby Gear & Furniture
                Battery Stores
                Bespoke Clothing
                Books, Mags, Music & Video
                Farming Equipment
                Fashion
                Fireworks
                Fitness/Exercise Equipment
                Flea Markets
                Flowers & Gifts
                Gemstones & Minerals
                Gold Buyers
                Guns & Ammo
                Head Shops
                High Fidelity Audio Equipment
                Hobby Shops
                Home & Garden
                Horse Equipment Shops
                Jewelry
                Knitting Supplies
                Livestock Feed & Supply
                Luggage
                Medical Supplies
                Military Surplus
                Mobile Phone Accessories
                Mobile Phones
                Motorcycle Gear
                Musical Instruments & Teachers
                Office Equipment
                Outlet Stores
                Packing Supplies
                Pawn Shops
                Perfume
                Personal Shopping
                Photography Stores & Services
                Pool & Billiards
                Pop-up Shops
                Props
                Public Markets
                Religious Items
                Safe Stores
                Safety Equipment
                Shopping Centers
                Souvenir Shops
                Spiritual Shop
                Sporting Goods
                Sunglasses
                Tabletop Games
                Teacher Supplies
                Thrift Stores
                Tobacco Shops
                Toy Stores
                Trophy Shops
                Uniforms
                Used Bookstore
                Vape Shops
                Vitamins & Supplements
                Watches
                Wholesale Stores
                Wigs";
            #endregion (PrimaryList)

            #region Arts & Crafts
            _artsCrafts = @"Art Supplies
                Cards & Stationery
                Cooking Classes
                Costumes
                Embroidery & Crochet
                Fabric Stores
                Framing
                Paint-Your-Own Pottery";
            #endregion (Arts & Crafts)

            #region Books & Mags
            _books = @"Bookstores
                Comic Books
                Music & DVDs
                Newspapers & Magazines
                Video Game Stores
                Videos & Video Game Rental
                Vinyl Records";
            #endregion (Books & Mags)

            #region Fashion
            _fashion = @"Accessories
                Ceremonial Clothing
                Children’s Clothing
                Clothing Rental
                Department Stores
                Formal Wear
                Fur Clothing
                Hats
                Leather Goods
                Lingerie
                Maternity Wear
                Men’s Clothing
                Plus Size Fashion
                Shoe Stores
                Sports Wear
                Dance Wear
                Surf Shop
                Swimwear
                Traditional Clothing
                Used, Vintage & Consignment
                Women’s Clothing";
            #endregion (fASHION)

            #region Home & Garden
            _homeGarden = @"Appliances
                Candle Stores
                Christmas Trees
                Furniture Stores
                Grilling Equipment
                Hardware Stores
                Holiday Decorations
                Home Decor
                Hot Tub & Pool
                Kitchen & Bath
                Lighting Stores
                Mattresses
                Nurseries & Gardening
                Outdoor Furniture Stores
                Paint Stores
                Playsets
                Pumpkin Patches
                Rugs
                Sheds & Outdoor Storage
                Tableware";
            #endregion (Home & Garden)

            #region Sporting Goods
            _sportingGoods = @"Bikes
                Dive Shops
                Golf Equipment
                Hockey Equipment
                Hunting & Fishing Supplies
                Outdoor Gear
                Skate Shops
                Ski & Snowboard Shops
                Sports & Dance Wear";
            #endregion (Sporting Goods)

            #endregion (Shopping)


        }
        #endregion (Initialize Data)

        private int GetCount() {
            int iReturn = _bizCats.Count;
            foreach(BizCat oCat in _bizCats) {
                iReturn += oCat.GetCount();
            }
            return iReturn;
        }
        #region Properties
        public int BizCatCount { get => GetCount(); }
        public List<BizCat> BizCats { get => _bizCats; set => _bizCats = value; }
        #endregion (Properties)


    }
}
