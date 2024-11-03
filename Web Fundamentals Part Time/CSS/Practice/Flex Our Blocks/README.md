# Flex our Blocks Assignment

## Objective
The goal of this assignment is to practice using CSS Flexbox to arrange blocks on a web page. You will replicate the layout shown in the reference image below by adjusting the provided CSS code. This exercise will help you understand how to use margin and padding to create spacing and how to use `display: flex;` to organize elements properly.

![Flex our Blocks Reference](image.png)  

## HTML Structure
You will start with the following HTML structure for your layout:

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Position Practice</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
    <div class="container">
        <div class="top-nav"></div>
        <div class="row">
            <div class="side-nav"></div>
            <div class="main">
                <div class="row">
                    <div class="sub-content"></div>
                    <div class="sub-content"></div>
                    <div class="sub-content"></div>
                </div>
                <div id="advertisement"></div>
            </div>
        </div>
    </div>
</body>
</html>
```
And our starting CSS:

```
.container{
    width: 950px;
    background-color: silver;
    margin: 0px auto;
}
.top-nav {
    height: 150px;
    background-color: green;
}
.side-nav {
    height: 300px;
    width: 200px;
    background-color: blue;
}
.main {
    height: 400px;
    width: 700px;
    background-color: red;
}
.sub-content {
    height: 200px;
    width: 210px;
    background-color: yellow;
}
#advertisement {
    height: 120px;
    width: 660px;
    background-color: purple;
}
.row {
    /* TODO - what should go here? */
}

```

### Requirements
- Recreate the image above using flex properties

### Technologies Used
- HTML - For structuring the page.
- CSS - For styling the text elements as per the assignment.### Technologies Used
- HTML - For structuring the page.
- CSS - For styling the text elements as per the assignment.
