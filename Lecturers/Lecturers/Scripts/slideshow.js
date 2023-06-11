let slideIndex = 0;
showSlides();

function showSlides() {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    let dots = document.getElementsByClassName("dot");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
    setTimeout(showSlides, 2000); // Change image every 2 seconds
}



    const $ = document.querySelector.bind(document);
    const $$ = document.querySelectorAll.bind(document);
   // const tab_body = $$('.body_right_item_1');
    const tab_menu = $$('.menu_item');

        tab_menu.forEach((tab, index) => {
        const body_item = tab_body[index]

    tab.onclick = function () {
        $(".menu_item.active1").classList.remove("active1")
                //$(".body_right_item_1.active2").classList.remove("active2")

    this.classList.add("active1");
    //body_item.classList.add("active2");
            }

        })









    

