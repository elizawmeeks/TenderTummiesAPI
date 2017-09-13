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

                // Creating new instances of trigger
                var triggers = new Trigger[]
                {
                    new Trigger{
                        Food = "Dairy",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "High"
                    },
                    new Trigger{
                        Food = "Soy",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "High"
                    },
                    new Trigger{
                        Food = "Egg",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Almond",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Cashew",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Macademia Nut",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Walnut",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Pine Nut",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Rice",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Barley",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Wheat",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Oat",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Watermelon",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Honeydew",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Cantaloupe",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Orange",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Mandarin Orange",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Clementine",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Grapefruit",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Peanut",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Green Bean",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Pea",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Kidney Bean",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Black Bean",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Navy Bean",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Black Eyed Pea",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Chick Pea",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Chicken",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Turkey",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Anchovy",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID,
                        Severity = "Medium"
                    },
                    new Trigger{
                        Food = "Hemp",
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
                        Food = "Pear",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Peach",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Raspberry",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Strawberry",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Bluberry",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Blackberry",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Apple",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Banana",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Apricot",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Grape",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Lemon",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Lime",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Tomato",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Plum",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Cherry",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Avocado",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Corn",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Pork",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Beef",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Lamb",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Sunflower Seed",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Spinach",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Onion",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Potato",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Carrot",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Celery",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Sweet Potato",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Turnip",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Collared Greens",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Olive",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Broccoli",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Asparagus",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Kale",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Arugula",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Lettuce",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Bell Pepper",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Cabbage",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Cauliflower",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Safflower Oil",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Grapeseed Oil",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Cottonseed Oil",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Sugar",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Salt",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Pepper",
                        ChildID = children.Single(s => s.FirstName == "Sherman").ChildID
                    },
                    new Safe{
                        Food = "Herbs",
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
                        TriggerID = triggers.Single(t => t.Food == "Soy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Vomit").SymptomID,
                        Acute = true,
                        Chronic = false
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Soy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Soy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Body Temperature Change").SymptomID,
                        Acute = true,
                        Chronic = false
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Soy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Dairy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Vomit").SymptomID,
                        Acute = true,
                        Chronic = false
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Dairy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Dairy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Body Temperature Change").SymptomID,
                        Acute = true,
                        Chronic = false
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Dairy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Almond").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Almond").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Cashew").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Cashew").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Macademia Nut").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Macademia Nut").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Walnut").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Walnut").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Pine Nut").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Pine Nut").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Rice").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Rice").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Barley").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Barley").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Wheat").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Wheat").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Oat").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Oat").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Watermelon").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Watermelon").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Honeydew").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Honeydew").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Cantaloupe").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Cantaloupe").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Orange").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Orange").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Mandarin Orange").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Mandarin Orange").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Clementine").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Clementine").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Grapefruit").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Grapefruit").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Peanut").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Peanut").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Green Bean").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Green Bean").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Pea").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Pea").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Kidney Bean").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Kidney Bean").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Black Bean").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Black Bean").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Navy Bean").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Navy Bean").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Black Eyed Pea").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Black Eyed Pea").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Chick Pea").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Chick Pea").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Chicken").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Chicken").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Turkey").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Turkey").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Anchovy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Anchovy").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Restless Sleep").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Hemp").TriggerID,
                        SymptomID = symptoms.Single(s => s.Name == "Diarrhea").SymptomID,
                        Acute = true,
                        Chronic = true
                    },
                    new TriggerSymptom{
                        TriggerID = triggers.Single(t => t.Food == "Hemp").TriggerID,
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
                        TriggerID = triggers.Single(t => t.Food == "Soy").TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 8, 1)).ReactionID
                    },
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.Food == "Wheat").TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 9)).ReactionID
                    },
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.Food == "Egg").TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 9)).ReactionID
                    },
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.Food == "Dairy").TriggerID,
                        ReactionID = reactions.Single(r => r.StartDate == new DateTime(2017, 9, 9)).ReactionID
                    },
                    new ReactionTrigger { 
                        TriggerID = triggers.Single(t => t.Food == "Soy").TriggerID,
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
                        Food = "Orange",
                        StartDate = new DateTime(2015, 5, 2),
                        EndDate = new DateTime(2015, 5, 5),
                        Pass = false,
                        TriggerID = triggers.Single(t => t.Food == "Orange").TriggerID
                    },
                    new Trial { 
                        ChildID = children.Single(c => c.FirstName == "Sherman").ChildID,
                        Food = "Quinoa",
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
                        TrialID = trials.Single(t => t.Food == "Quinoa").TrialID,
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
                        TrialID = trials.Single(t => t.Food == "Quinoa").TrialID,
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
