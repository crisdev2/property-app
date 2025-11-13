// MongoDB Sample Data Script
// Run this script in MongoDB shell or MongoDB Compass

// Switch to PropertyDb database
use PropertyDb;

// Clear existing data (optional)
db.Owners.deleteMany({});
db.Properties.deleteMany({});
db.PropertyImages.deleteMany({});
db.PropertyTraces.deleteMany({});

// Insert sample owners
const owner1 = db.Owners.insertOne({
  name: "John Smith",
  address: "456 Oak Avenue, Seattle, WA 98101",
  photo: "https://randomuser.me/api/portraits/men/1.jpg",
  birthday: new Date("1975-03-15")
});

const owner2 = db.Owners.insertOne({
  name: "Sarah Johnson",
  address: "789 Pine Street, Portland, OR 97201",
  photo: "https://randomuser.me/api/portraits/women/2.jpg",
  birthday: new Date("1982-07-22")
});

const owner3 = db.Owners.insertOne({
  name: "Michael Chen",
  address: "321 Maple Drive, San Francisco, CA 94102",
  photo: "https://randomuser.me/api/portraits/men/3.jpg",
  birthday: new Date("1988-11-30")
});

// Insert sample properties
const property1 = db.Properties.insertOne({
  name: "Modern Downtown Apartment",
  address: "123 Main Street, Seattle, WA 98101",
  price: 450000,
  codeInternal: "PROP-001",
  year: 2020,
  idOwner: owner1.insertedId
});

const property2 = db.Properties.insertOne({
  name: "Luxury Waterfront Condo",
  address: "555 Harbor View, Seattle, WA 98109",
  price: 850000,
  codeInternal: "PROP-002",
  year: 2021,
  idOwner: owner1.insertedId
});

const property3 = db.Properties.insertOne({
  name: "Cozy Suburban House",
  address: "789 Elm Street, Portland, OR 97213",
  price: 325000,
  codeInternal: "PROP-003",
  year: 2018,
  idOwner: owner2.insertedId
});

const property4 = db.Properties.insertOne({
  name: "Spacious Family Home",
  address: "432 Cedar Lane, Portland, OR 97206",
  price: 520000,
  codeInternal: "PROP-004",
  year: 2019,
  idOwner: owner2.insertedId
});

const property5 = db.Properties.insertOne({
  name: "Penthouse Suite",
  address: "100 Mission Street, San Francisco, CA 94105",
  price: 1200000,
  codeInternal: "PROP-005",
  year: 2022,
  idOwner: owner3.insertedId
});

const property6 = db.Properties.insertOne({
  name: "Charming Victorian",
  address: "678 Haight Street, San Francisco, CA 94117",
  price: 975000,
  codeInternal: "PROP-006",
  year: 1905,
  idOwner: owner3.insertedId
});

// Insert sample property images
db.PropertyImages.insertMany([
  {
    idProperty: property1.insertedId,
    file: "https://images.unsplash.com/photo-1545324418-cc1a3fa10c00?w=800",
    enabled: true
  },
  {
    idProperty: property2.insertedId,
    file: "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=800",
    enabled: true
  },
  {
    idProperty: property3.insertedId,
    file: "https://images.unsplash.com/photo-1568605114967-8130f3a36994?w=800",
    enabled: true
  },
  {
    idProperty: property4.insertedId,
    file: "https://images.unsplash.com/photo-1570129477492-45c003edd2be?w=800",
    enabled: true
  },
  {
    idProperty: property5.insertedId,
    file: "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=800",
    enabled: true
  },
  {
    idProperty: property6.insertedId,
    file: "https://images.unsplash.com/photo-1564013799919-ab600027ffc6?w=800",
    enabled: true
  }
]);

// Insert sample property traces
db.PropertyTraces.insertMany([
  {
    idProperty: property1.insertedId,
    dateSale: new Date("2023-01-15"),
    name: "Initial Sale",
    value: 450000,
    tax: 4500
  },
  {
    idProperty: property2.insertedId,
    dateSale: new Date("2023-03-20"),
    name: "Initial Sale",
    value: 850000,
    tax: 8500
  },
  {
    idProperty: property3.insertedId,
    dateSale: new Date("2022-11-10"),
    name: "Resale",
    value: 325000,
    tax: 3250
  },
  {
    idProperty: property4.insertedId,
    dateSale: new Date("2023-05-08"),
    name: "Initial Sale",
    value: 520000,
    tax: 5200
  },
  {
    idProperty: property5.insertedId,
    dateSale: new Date("2023-08-22"),
    name: "Initial Sale",
    value: 1200000,
    tax: 12000
  },
  {
    idProperty: property6.insertedId,
    dateSale: new Date("2023-02-14"),
    name: "Renovation Sale",
    value: 975000,
    tax: 9750
  }
]);

print("Sample data inserted successfully!");
print("Owners: " + db.Owners.countDocuments());
print("Properties: " + db.Properties.countDocuments());
print("Property Images: " + db.PropertyImages.countDocuments());
print("Property Traces: " + db.PropertyTraces.countDocuments());
