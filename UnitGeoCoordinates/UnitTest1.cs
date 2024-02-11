using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabWork09;
using System;
using System.IO;
using System.Text;

namespace UnitGeoCoordinates
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UnitTest2
        {

            [TestMethod]
            public void GeoCoordinatesArray_Constructor_WithRandom_ThrowsExceptionForNonPositiveCount()
            {
                // Arrange
                int count = 0;
                Random rnd = new Random();

                // Act & Assert
                Assert.ThrowsException<ArgumentException>(() => new GeoCoordinatesArray(count, rnd));
            }

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GeoCoordinatesArray_FindNearestToZeroIslandIndex_ThrowsExceptionForEmptyArray()
        {
            // Arrange
            var geoArray = new GeoCoordinatesArray();

            // Act
            geoArray.FindNearestToZeroIslandIndex();
        }
        [TestMethod]
        public void GeoCoordinatesArray_CopyConstructor_CreatesDeepCopy()
        {
            // Arrange
            var original = new GeoCoordinatesArray(3, new Random());

            // Act
            var copy = new GeoCoordinatesArray(original);

            // Assert
            Assert.IsFalse(ReferenceEquals(original[0], copy[0]));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeoCoordinatesArray_ParameterizedConstructor_ThrowsExceptionForZeroCount()
        {
            // Arrange
            int count = 0;
            var rnd = new Random();

            // Act
            var geoArray = new GeoCoordinatesArray(count, rnd);
        }
        [TestMethod]
        public void GeoCoordinates_Equals_TwoEqualCoordinates_ReturnsTrue()
        {
            // Arrange
            var geoCoord1 = new GeoCoordinates(10.0, 20.0);
            var geoCoord2 = new GeoCoordinates(10.0, 20.0);

            // Act & Assert
            Assert.IsTrue(geoCoord1.Equals(geoCoord2));
        }
        [TestMethod]
        public void GeoCoordinates_Equals_TwoDifferentCoordinates_ReturnsFalse()
        {
            // Arrange
            var geoCoord1 = new GeoCoordinates(10.0, 20.0);
            var geoCoord2 = new GeoCoordinates(30.0, 40.0);

            // Act & Assert
            Assert.IsFalse(geoCoord1.Equals(geoCoord2));
        }
        [TestMethod]
        public void GeoCoordinates_ParameterizedConstructor_InitializesWithGivenValues()
        {
            // Arrange
            double lat = 45.0;
            double lon = -75.0;

            // Act
            var geoCoord = new GeoCoordinates(lat, lon);

            // Assert
            Assert.AreEqual(lat, geoCoord.Latitude);
            Assert.AreEqual(lon, geoCoord.Longitude);
        }
        [TestMethod]
        public void GeoCoordinates_DefaultConstructor_InitializesWithDefaultValues()
        {
            // Arrange
            var geoCoord = new GeoCoordinates();

            // Act & Assert
            Assert.AreEqual(0.01, geoCoord.Latitude);
            Assert.AreEqual(0.01, geoCoord.Longitude);
        }
        [TestMethod]
        public void GeoCoordinates_Distance_Static()
        {
            // Arrange
            var location1 = new GeoCoordinates(0, 0);
            var location2 = new GeoCoordinates(0, 1);
            double expectedDistance = 111.195;

            // Act
            double distance = GeoCoordinates.DistanceSt(location1, location2);

            // Assert
            Assert.AreEqual(expectedDistance, distance, 0.001);
        }
        [TestMethod]
        public void GeoCoordinates_Equals()
        {
            // Arrange
            var location1 = new GeoCoordinates(10, 20);
            var location2 = new GeoCoordinates(10, 20);
            var location3 = new GeoCoordinates(30, 40);

            // Assert
            Assert.IsTrue(location1.Equals(location2));
            Assert.IsFalse(location1.Equals(location3));
            Assert.IsFalse(location1.Equals(null));
            Assert.IsFalse(location1.Equals("string"));
        }
        [TestMethod]
        public void GeoCoordinates_Equals1()
        {
            // Arrange
            var geo1 = new GeoCoordinates(50.0, 30.0);
            var geo2 = new GeoCoordinates(50.0, 30.0);
            var geo3 = new GeoCoordinates(60.0, 40.0);

            // Assert
            Assert.AreEqual(geo1, geo2);
            Assert.AreNotEqual(geo1, geo3);
        }
        [TestMethod]
        public void GeoCoordinatesArray_Indexer()
        {
            // Arrange
            var geoArray = new GeoCoordinatesArray(3, new System.Random());

            // Act
            var coordinate = geoArray[1];

            // Assert
            Assert.IsNotNull(coordinate);
        }
        [TestMethod]
        public void GeoCoordinates_Constructors()
        {
            // Arrange & Act
            var geo1 = new GeoCoordinates();
            var geo2 = new GeoCoordinates(50.0, 30.0);

            // Assert
            Assert.AreEqual(0.01, geo1.Latitude);
            Assert.AreEqual(0.01, geo1.Longitude);
            Assert.AreEqual(50.0, geo2.Latitude);
            Assert.AreEqual(30.0, geo2.Longitude);
        }
        [TestMethod]
        public void GeoCoordinates_ExplicitConversion()
        {
            // Arrange
            var geo1 = new GeoCoordinates(0.0, 0.0);
            var geo2 = new GeoCoordinates(50.0, 30.0);

            // Act
            bool result1 = (bool)geo1;
            bool result2 = (bool)geo2;

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        [TestMethod]
        public void GeoCoordinates_ImplicitConversion()
        {
            // Arrange
            var geo1 = new GeoCoordinates(50.0, 30.0);
            var geo2 = new GeoCoordinates(-50.0, -30.0);
            var geo3 = new GeoCoordinates(0.0, 0.0);

            // Act
            string result1 = geo1;
            string result2 = geo2;
            string result3 = geo3;

            // Assert
            Assert.AreEqual("Восточная долгота", result1);
            Assert.AreEqual("Западная долгота", result2);
            Assert.AreEqual("Нулевой меридиан", result3);
        }
    }
}