using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TenderTummiesAPI.Models;
using System.Threading.Tasks;

namespace TenderTummiesAPI.Data
{
    // Class to seed our database with data for testing purposes.
    public static class DbInitializer
    {
        // Method runs on startup to initialize dummy data.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TenderTummiesAPIContext(serviceProvider.GetRequiredService<DbContextOptions<TenderTummiesAPIContext>>()))
            {
                // Look for any Customers.
                if (context.TrialEvent.Any())
                {
                    return;   // DB has been seeded, the rest of this method doesn't need to run.
                }
                // Creating new instances of Child
                var children = new Child[]
                {
                    new Child { 
                        UserID = "User1",
                        FirstName = "Sherman",
                        LastName = "Meeks",
                        WtNumber = 38,
                        WtUnit = "lbs",
                        Gender = "Boy",
                        Age = 3

                    },
                    new Child { 
                        UserID = "User1",
                        FirstName = "Ruby",
                        LastName = "Meeks",
                        WtNumber = 40,
                        WtUnit = "lbs",
                        Gender = "Girl",
                        Age = 5
                    }
                };
                // Adds each new child into the context
                foreach (Child i in children)
                {
                    context.Child.Add(i);
                }
                // Saves the children to the database
                context.SaveChanges();

                // Creating new instances of Symptom
                var symptoms = new Symptom[]
                {
                    new Symptom { 
                        Name = "Vomit"
                    },
                     new Symptom { 
                        Name = "Diarrhea"
                    },
                    new Symptom { 
                        Name = "Lethargy"
                    },
                    new Symptom { 
                        Name = "Dehydration"
                    },
                    new Symptom { 
                        Name = "Blood Pressure Change"
                    },
                    new Symptom { 
                        Name = "Body Temperature Change"
                    },
                    new Symptom { 
                        Name = "Weight Loss"
                    },
                    new Symptom { 
                        Name = "Restless Sleep"
                    },
                    new Symptom { 
                        Name = "Shock"
                    },
                    new Symptom { 
                        Name = "Sores"
                    },
                    new Symptom { 
                        Name = "Bleeding Sores"
                    },
                    new Symptom { 
                        Name = "Distended stomach"
                    }
                };

                // Adds each new symptom into the context
                foreach (Symptom p in symptoms)
                {
                    context.Symptom.Add(p);
                }
                // Saves the symptoms to the database
                context.SaveChanges();

                var food = new Food[]
                {
                    new Food{
                        Name = "Dairy"
                    },
                    new Food{
                        Name = "Soy"
                    },
                    new Food{
                        Name = "Egg"
                    },
                    new Food{
                        Name = "Almond"
                    },
                    new Food{
                        Name = "Cashew"
                    },
                    new Food{
                        Name = "Macademia Nut"
                    },
                    new Food{
                        Name = "Walnut"
                    },
                    new Food{
                        Name = "Pine Nut"
                    },
                    new Food{
                        Name = "Rice"
                    },
                    new Food{
                        Name = "Barley"
                    },
                    new Food{
                        Name = "Wheat"
                    },
                    new Food{
                        Name = "Oat"
                    },
                    new Food{
                        Name = "Watermelon"
                    },
                    new Food{
                        Name = "Honeydew"
                    },
                    new Food{
                        Name = "Cantaloupe"
                    },
                    new Food{
                        Name = "Orange"
                    },
                    new Food{
                        Name = "Mandarin Orange"
                    },
                    new Food{
                        Name = "Clementine"
                    },
                    new Food{
                        Name = "Grapefruit"
                    },
                    new Food{
                        Name = "Peanut"
                    },
                    new Food{
                        Name = "Green Bean"
                    },
                    new Food{
                        Name = "Pea"
                    },
                    new Food{
                        Name = "Kidney Bean"
                    },
                    new Food{
                        Name = "Red Bean"
                    },
                    new Food{
                        Name = "Black Bean"
                    },
                    new Food{
                        Name = "Navy Bean"
                    },
                    new Food{
                        Name = "Black Eyed Pea"
                    },
                    new Food{
                        Name = "Chick Pea"
                    },
                    new Food{
                        Name = "Chicken"
                    },
                    new Food{
                        Name = "Turkey"
                    },
                    new Food{
                        Name = "Anchovy"
                    },
                    new Food{
                        Name = "Hemp"
                    },
                    new Food{
                        Name = "Pear"
                    },
                    new Food{
                        Name = "Peach"
                    },
                    new Food{
                        Name = "Strawberry"
                    },
                    new Food{
                        Name = "Raspberry"
                    },
                    new Food{
                        Name = "Blueberry"
                    },
                    new Food{
                        Name = "Blackberry"
                    },
                    new Food{
                        Name = "Apple"
                    },
                    new Food{
                        Name = "Banana"
                    },
                    new Food{
                        Name = "Apricot"
                    },
                    new Food{
                        Name = "Grape"
                    },
                    new Food{
                        Name = "Lemon"
                    },
                    new Food{
                        Name = "Lime"
                    },
                    new Food{
                        Name = "Tomato"
                    },
                    new Food{
                        Name = "Plum"
                    },
                    new Food{
                        Name = "Cherry"
                    },
                    new Food{
                        Name = "Avocado"
                    },
                    new Food{
                        Name = "Corn"
                    },
                    new Food{
                        Name = "Pork"
                    },
                    new Food{
                        Name = "Beef"
                    },
                    new Food{
                        Name = "Lamb"
                    },
                    new Food{
                        Name = "Sunflower Seed"
                    },
                    new Food{
                        Name = "Spinach"
                    },
                    new Food{
                        Name = "Onion"
                    },
                    new Food{
                        Name = "Potato"
                    },
                    new Food{
                        Name = "Carrot"
                    },
                    new Food{
                        Name = "Celery"
                    },
                    new Food{
                        Name = "Sweet Potato"
                    },
                    new Food{
                        Name = "Turnip"
                    },
                    new Food{
                        Name = "Collared Greens"
                    },
                    new Food{
                        Name = "Olive"
                    },
                    new Food{
                        Name = "Broccoli"
                    },
                    new Food{
                        Name = "Asparagus"
                    },
                    new Food{
                        Name = "Kale"
                    },
                    new Food{
                        Name = "Arugula"
                    },
                    new Food{
                        Name = "Lettuce"
                    },
                    new Food{
                        Name = "Bell Pepper"
                    },
                    new Food{
                        Name = "Cabbage"
                    },
                    new Food{
                        Name = "Cauliflower"
                    },
                    new Food{
                        Name = "Safflower Oil"
                    },
                    new Food{
                        Name = "Grapeseed Oil"
                    },
                    new Food{
                        Name = "Cottonseed Oil"
                    },
                    new Food{
                        Name = "Rapeseed Oil"
                    },
                    new Food{
                        Name = "Canola Oil"
                    },
                    new Food{
                        Name = "Tuna"
                    },
                    new Food{
                        Name = "Salmon"
                    },
                    new Food{
                        Name = "Tilapia"
                    },
                    new Food{
                        Name = "Trout"
                    },
                    new Food{
                        Name = "Venison"
                    },
                    new Food{
                        Name = "Duck"
                    }
                };

                foreach (Food f in food){
                    context.Food.Add(f);
                }
                context.SaveChanges();

                // Creating new instances of trigger
                var triggers = new Trigger[]
                {
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Dairy").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "High"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Soy").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "High"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Egg").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Almond").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Cashew").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Macademia Nut").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Walnut").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Pine Nut").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Rice").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Barley").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Wheat").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Oat").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Watermelon").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Honeydew").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Cantaloupe").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Orange").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Mandarin Orange").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Clementine").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Grapefruit").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Peanut").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Green Bean").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Pea").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Kidney Bean").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Black Bean").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Navy Bean").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Black Eyed Pea").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Chick Pea").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Chicken").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Turkey").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Anchovy").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        FoodID = food.Single(f => f.Name == "Hemp").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    }
                };
                // Adds each new trigger into the context
                foreach (Trigger t in triggers)
                {
                    context.Trigger.Add(t);
                }
                // Saves the additions to the database
                context.SaveChanges();

                // Creating new instances of safes
                var safes = new Safe[]
                {
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Pear").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Peach").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Raspberry").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Strawberry").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Blueberry").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Blackberry").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Apple").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Banana").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Apricot").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Grape").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Lemon").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Lime").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Tomato").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Plum").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Cherry").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Avocado").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Corn").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Pork").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Beef").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Lamb").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Sunflower Seed").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Spinach").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Onion").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Potato").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Carrot").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Celery").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Sweet Potato").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Turnip").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Collared Greens").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Olive").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Broccoli").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Asparagus").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Kale").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Arugula").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Lettuce").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Bell Pepper").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Cabbage").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Cauliflower").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Safflower Oil").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Grapeseed Oil").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Cottonseed Oil").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        FoodID = food.Single(f => f.Name == "Canola Oil").FoodID,
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    }
                };
                // Adds each new safe into the context
                foreach(Safe p in safes)
                {
                    context.Safe.Add(p);
                }
                // Saves the additions to the database
                context.SaveChanges();

                // Creating new instances of trigger symptom
                var triggerSymptoms = new TriggerSymptom[]
                {
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Soy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Vomit").SymptomID,
                        Acute = true,
                        Chronic = false
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Soy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Soy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Body Temperature Change").SymptomID,
                        Acute = true,
                        Chronic = false
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Soy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Dairy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Vomit").SymptomID,
                        Acute = true,
                        Chronic = false
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Dairy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Dairy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Body Temperature Change").SymptomID,
                        Acute = true,
                        Chronic = false
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Dairy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Almond").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Almond").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Cashew").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Cashew").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Macademia Nut").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Macademia Nut").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Walnut").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Walnut").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Pine Nut").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Pine Nut").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Rice").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Rice").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Barley").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Barley").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Wheat").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Wheat").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Oat").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Oat").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Watermelon").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Watermelon").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Honeydew").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Honeydew").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Cantaloupe").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Cantaloupe").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Orange").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Orange").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Mandarin Orange").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Mandarin Orange").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Clementine").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Clementine").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Grapefruit").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Grapefruit").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Peanut").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Peanut").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Green Bean").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Green Bean").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Pea").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Pea").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Kidney Bean").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Kidney Bean").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Black Bean").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Black Bean").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Navy Bean").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Navy Bean").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Black Eyed Pea").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Black Eyed Pea").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Chick Pea").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Chick Pea").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Chicken").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Chicken").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Turkey").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Turkey").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Anchovy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Anchovy").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Hemp").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Hemp").FoodID).TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    }

                };
                // Adds each new trigger symptom into the context
                foreach(TriggerSymptom p in triggerSymptoms)
                {
                    context.TriggerSymptom.Add(p);
                }
                context.SaveChanges();

                // Creating new instances of ingestion
                var ingestions = new Ingestion[]
                {
                    new Ingestion { 
                        Name = "Direct Ingestion"
                    },
                    new Ingestion { 
                        Name = "Cross Contamination"
                    },
                    new Ingestion { 
                        Name = "Breastmilk"
                    },
                    new Ingestion { 
                        Name = "G Tube"
                    },
                    new Ingestion { 
                        Name = "NG Tube"
                    }
                };
                // Adds each new ingestion into the context
                foreach (Ingestion i in ingestions)
                {
                    context.Ingestion.Add(i);
                }
                // Saves the additions to the database
                context.SaveChanges();

                // Creating new instances of reaction
                var reactions = new Reaction[]
                {
                    new Reaction { 
                        ChildID = children.Single(c => c.FirstName == "Sherman").ChildID,
                        FoodType = "Soy Sauce",
                        StartDate = new DateTime(2017, 8, 1),
                        EndDate = new DateTime(2017, 8, 7),
                        IngestionID = ingestions.Single(t => t.Name == "Cross Contamination").IngestionID,
                        Description = "I drank out of a cup that Sherman drank after me",
                    },
                    new Reaction { 
                        ChildID = children.Single(c => c.FirstName == "Sherman").ChildID,
                        FoodType = "Cake Batter",
                        StartDate = new DateTime(2017, 9, 9),
                        IngestionID = ingestions.Single(t => t.Name == "Direct Ingestion").IngestionID,
                        Description = "Sherman ate cake batter while he was helping make cupcakes",
                    },
                    new Reaction {
                        ChildID = children.Single(c => c.FirstName == "Sherman").ChildID,
                        FoodType = "Quinoa",
                        StartDate = new DateTime(2017, 9, 2),
                        IngestionID = ingestions.Single(i => i.Name == "Direct Ingestion").IngestionID,
                        Description = "Gave him quinoa for a trial :(",
                    }
                };
                // Adds each new rxn into the context
                foreach (Reaction rxn in reactions)
                {
                    context.Reaction.Add(rxn);
                }
                // Saves the additions to the database
                context.SaveChanges();
                
                // Creating new instances of reactionTrigger
                var reactionTriggers = new ReactionTrigger[]
                {
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Soy").FoodID).TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 8, 1)).ReactionID
                    },
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Wheat").FoodID).TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 9)).ReactionID
                    },
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Egg").FoodID).TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 9)).ReactionID
                    },
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Dairy").FoodID).TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 9)).ReactionID
                    },
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Soy").FoodID).TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 9)).ReactionID
                    }
                };
                // Adds each new ReactionTrigger into the context
                foreach (ReactionTrigger rxnT in reactionTriggers)
                {
                    context.ReactionTrigger.Add(rxnT);
                }
                // Saves the additions to the database
                context.SaveChanges();

                // Creating new instances of Trial
                var trials = new Trial[]
                {
                    new Trial { 
                        ChildID = children.Single(c => c.FirstName == "Sherman").ChildID,
                        FoodID = food.Single(f => f.Name == "Orange").FoodID,
                        StartDate = new DateTime(2015, 5, 2),
                        EndDate = new DateTime(2015, 5, 5),
                        Pass = false,
                        TriggerID = triggers.Single(t => t.FoodID == food.Single(f => f.Name == "Orange").FoodID).TriggerID
                    },
                    new Trial { 
                        ChildID = children.Single(c => c.FirstName == "Sherman").ChildID,
                        FoodID = food.Single(f => f.Name == "Quinoa").FoodID,
                        StartDate = new DateTime(2017, 9, 2)
                    }
                };
                // Adds each new trial into the context
                foreach (Trial t in trials)
                {
                    context.Trial.Add(t);
                }
                // Saves the additions to the database
                context.SaveChanges();

                // Creating new instances of reactionEvent
                var reactionEvents = new ReactionEvent[]
                {
                    new ReactionEvent {
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 2)).ReactionID,
                        TrialID = trials.Single(t => t.FoodID == food.Single(f => f.Name == "Quinoa").FoodID).TrialID,
                        Acute = false,
                        Chronic = true,
                        Description = "Sherman woke up about two hours after bedtime",
                        DateTime = new DateTime(2017, 9, 2, 21, 4, 00)
                    },
                    new ReactionEvent {
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 9)).ReactionID,
                        Acute = true,
                        Chronic = false,
                        Description = "Sherman threw up, had chills, and couldn't sleep",
                        DateTime = new DateTime(2017, 9, 9, 19, 00, 00)
                    }
                };
                // Adds each new ReactionEvent into the context
                foreach (ReactionEvent r in reactionEvents)
                {
                    context.ReactionEvent.Add(r);
                }
                // Saves the additions to the database
                context.SaveChanges();

                // Creating new instances of reactionEventSymptom
                var reactionEventSymptoms = new ReactionEventSymptom[]
                {
                    new ReactionEventSymptom { 
                        ReactionEventID = reactionEvents
                            .Single(r => r.DateTime == new DateTime(2017, 9, 2, 21, 4, 00))
                            .ReactionEventID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID
                    },
                    new ReactionEventSymptom { 
                        ReactionEventID = reactionEvents
                            .Single(r => r.DateTime == new DateTime(2017, 9, 9, 19, 00, 00))
                            .ReactionEventID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID
                    },
                    new ReactionEventSymptom { 
                        ReactionEventID = reactionEvents
                            .Single(r => r.DateTime == new DateTime(2017, 9, 9, 19, 00, 00))
                            .ReactionEventID,
                        SymptomID = symptoms.Single(s => s.Name == "Vomit").SymptomID
                    },
                    new ReactionEventSymptom { 
                        ReactionEventID = reactionEvents
                            .Single(r => r.DateTime == new DateTime(2017, 9, 9, 19, 00, 00))
                            .ReactionEventID,
                        SymptomID = symptoms.Single(s => s.Name == "Body Temperature Change").SymptomID
                    }
                };
                foreach (ReactionEventSymptom res in reactionEventSymptoms)
                {
                    context.ReactionEventSymptom.Add(res);
                }
                // Saves the additions to the database
                context.SaveChanges();

                // Creating new instances of trialEvent
                var trialEvents = new TrialEvent[]
                {
                    new TrialEvent {
                        TrialID = trials.Single(t => t.FoodID == food.Single(f => f.Name == "Quinoa").FoodID).TrialID,
                        Quantity = "1 cup",
                        FoodType = "Quinoa with pepper and olive oil",
                        DateTime = new DateTime(2017, 9, 9, 17, 00, 00)
                    }
                };
                // Adds each new trialEvent into the context
                foreach (TrialEvent te in trialEvents)
                {
                    context.TrialEvent.Add(te);
                }
                // Saves the additions to the database
                context.SaveChanges();

            }
       }
    }
}
