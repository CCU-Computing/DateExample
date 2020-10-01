using System;
using Moq;
using Xunit;

namespace DateProject.Tests
{
    public class DateTests
    {
        [Fact]
        public void MonthName_MonthIs1_ReturnsJanuary(){
            //Arrange
            Date d = new Date();

            //Act
            string monthName = d.MonthName;

            //Assert
            Assert.Equal("January", monthName);

        }
        [Fact]
        public void MonthName_MonthIs2_ReturnsFebruary() {
            //Arrange
            Date d = new Date(2020, 2, 1);

            //Act
            string monthName = d.MonthName;

            //Assert
            Assert.Equal("February",monthName);
        }
        [Theory]
        [InlineData(12, "December")]
        [InlineData(11, "November")]
        [InlineData(10, "October")]
        
        public void MonthName_Month1To12_ReturnsCorrectMonth(int monthNum, string name) {
            //Arrange
            Date d = new Date(2020, monthNum, 1);

            //Act
            string monthName = d.MonthName;

            //Assert
            Assert.Equal(name,monthName);
        }

        [Fact]
        public void MonthConstructor_YearIsTooBig_ThrowsArgumentOutOfRange() {
            //Arrange
            int year = 10000;

            //Act
            Date d;// = new Date(year, 1, 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(year,1,1));
        }
         [Fact]
        public void DateConstructor_YearIsTooSmall_ThrowsArgumentOutOfRange() {
            //Arrange
            int year = -10000;

            //Act
            Date d;// = new Date(year, 1, 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(year,1,1));
        }

        [Fact]
        public void DateConstructor_MonthTooSmall_ThrowsArgumentOutOfRangeException() {
             int month = 0;

            //Act
            Date d;// = new Date(year, 1, 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(2020,month,1));
        }      
         [Fact]
        public void DateConstructor_MonthTooBig_ThrowsArgumentOutOfRangeException() {
             int month = 13;

            //Act
            Date d;// = new Date(year, 1, 1);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(2020,month,1));
        }     

        [Fact]
        public void DateConstructor_MonthIs30DayMax_DayIsBetween1And30_DateSetAccordingToParameters() {
            //Arrange
            int day = 30;
            int month = 4;
            //Act
            Date d = new Date(2020,month, day );
            //Assert
            Assert.Equal(2020,d.Year);
            Assert.Equal(month,d.Month);
            Assert.Equal(day, d.Day);
        }  
         [Fact]
        public void DateConstructor_MonthIs30DayMax_DayIsNotBetween1And30_ThrowsArgumentInvalidException() {
            //Arrange
            int day = 31;
            int month = 4;
            //Act
            Date d;
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>d=new Date(2020,month,day));
        } 
        //Add test for MonthIs31DayMax and DayBetween1And31
        //Add test for MonthIs31DayMax and DayNotBetween1And31
        //Add test for MonthIsFebruary and DayBetween1And28
        //Add test for MonthIsFebruary and DayNotBetween1and28
       
      
     
    }
}
