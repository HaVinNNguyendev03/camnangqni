
const dropdown = document.querySelectorAll('.boxdatatoken-img');


document.addEventListener('click', (e) => {
   
    if (!e.target.closest('.boxdatatoken-img')) {
       
        dropdown.forEach(item => {
            item.closest('.boxdatatoken').classList.remove('active');
        });
    }
});

dropdown.forEach(item => {
    item.addEventListener('click', (e) => {
        e.preventDefault();

       
        dropdown.forEach(otherItem => {
            if (otherItem !== item) {
                otherItem.closest('.boxdatatoken').classList.remove('active');
            }
        });

       
        item.closest('.boxdatatoken').classList.toggle('active');
    });
})