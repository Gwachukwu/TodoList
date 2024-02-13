using TodoListAPI.Models;
using System;

namespace TodoListAPITests.Models
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void CanCreateTodoItemWithDefaultValues()
        {
            var todoItem = new TodoItem();
            Assert.IsNotNull(todoItem);
            Assert.AreEqual(default(Guid), todoItem.Id);
            Assert.IsNull(todoItem.DueDate);
            Assert.IsNull(todoItem.CompletedDate);
            Assert.IsNull(todoItem.Description);
        }

        [TestMethod]
        public void CanAssignValuesToTodoItemProperties()
        {
            // Arrange
            var todoItem = new TodoItem();
            var id = Guid.NewGuid();
            var dueDate = DateTime.Now.AddDays(1);
            var completedDate = DateTime.Now;
            var description = "Test Todo Item";

            // Act
            todoItem.Id = id;
            todoItem.DueDate = dueDate;
            todoItem.CompletedDate = completedDate;
            todoItem.Description = description;

            // Assert
            Assert.AreEqual(id, todoItem.Id);
            Assert.AreEqual(dueDate, todoItem.DueDate);
            Assert.AreEqual(completedDate, todoItem.CompletedDate);
            Assert.AreEqual(description, todoItem.Description);
        }

        [TestMethod]
        public void TodoItemIsIncompleteWhenCreated()
        {
            var todoItem = new TodoItem();
            Assert.IsNull(todoItem.CompletedDate);
        }

        [TestMethod]
        public void TodoItemIsCompleteWhenCompletedDateIsSet()
        {
            var todoItem = new TodoItem
            {
                CompletedDate = DateTime.Now
            };
            bool isComplete = todoItem.CompletedDate.HasValue;
            Assert.IsTrue(isComplete);
        }
    }
}
