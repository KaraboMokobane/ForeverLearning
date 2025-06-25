// site.js

// Wait for the DOM to load
document.addEventListener("DOMContentLoaded", function () {
    // Find all elements with class 'course-card'
    const courseCards = document.querySelectorAll(".course-card");

    // Add a click event listener to each course card
    courseCards.forEach(card => {
        card.addEventListener("click", function () {
            const courseTitle = this.getAttribute("data-title") || "this course";
            alert(`You clicked on "${courseTitle}"`);
        });
    });
});
