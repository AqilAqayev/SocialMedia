<script>
    // Backend-dən alınan məlumatı JavaScript-də istifadə edin
    const allStories = @Html.Raw(ViewBag.AllStoriesJson);

    const storiesContainer = document.querySelector(".stories-container");
    const storyFull = document.querySelector(".story-full");
    const storyFullContent = storyFull.querySelector(".content");
    const storyFullImage = storyFull.querySelector("img");
    const storyFullTitle = storyFull.querySelector(".title");
    const closeBtn = storyFull.querySelector(".close-btn");
    const leftArrow = storyFull.querySelector(".left-arrow");
    const rightArrow = storyFull.querySelector(".right-arrow");

    let currentStoryIndex = 0;
    let currentUserStories = [];

    // Storyləri əlavə et
    allStories.forEach((user, index) => {
        const content = document.createElement("div");
    content.classList.add("content");

    const img = document.createElement("img");
    img.setAttribute("src", user.profilePicture);
    const name = document.createElement("p");
    name.textContent = user.userName;

    content.appendChild(img);
    content.appendChild(name);
    storiesContainer.appendChild(content);

        content.addEventListener("click", () => {
        currentStoryIndex = 0;
    currentUserStories = user.stories;
    openStory(user.userName);
        });
    });

    function openStory(userName) {
        storyFull.classList.add("active");
    showStory(userName);
    }

    function showStory(userName) {
        const story = currentUserStories[currentStoryIndex];
    storyFullImage.setAttribute("src", story.url);
    storyFullTitle.textContent = `${userName} - ${currentStoryIndex + 1}/${currentUserStories.length}`;
    }

    closeBtn.addEventListener("click", () => {
        storyFull.classList.remove("active");
    });

    leftArrow.addEventListener("click", () => {
        if (currentStoryIndex > 0) {
        currentStoryIndex--;
    showStory();
        }
    });

    rightArrow.addEventListener("click", () => {
        if (currentStoryIndex < currentUserStories.length - 1) {
        currentStoryIndex++;
    showStory();
        }
    });
</script>
