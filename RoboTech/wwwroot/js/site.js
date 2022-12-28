// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*product-detail*/
const imgs = document.querySelectorAll('.img-select a');
const imgBtns = [...imgs];
let imgId = 1;

imgBtns.forEach((imgItem) => {
    imgItem.addEventListener('click', (event) => {
        event.preventDefault();
        imgId = imgItem.dataset.id;
        slideImage();
    });
});

function slideImage() {
    const displayWidth = document.querySelector('.img-showcase img:first-child').clientWidth;

    document.querySelector('.img-showcase').style.transform = `translateX(${- (imgId - 1) * displayWidth}px)`;
}

window.addEventListener('resize', slideImage);

// product slider
var swiper = new Swiper(".mySwiper", {
    slidesPerView: 3,
    spaceBetween: 30,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
});

// payment opt switching
const pay_opts = document.querySelectorAll(".type");

for (const pay_opt of pay_opts) {
    function addSelected() {
        $(pay_opt).addClass('selected').siblings().removeClass('selected')
    }

    pay_opt.addEventListener("click", addSelected)

}

// dialog confirm payment
const dialog = (function () {
    let element, dialog, cancelBtn, okBtn;

    let animaArr = new Array(['fadeIn', 'fadeOut'], ['slideDown', 'slideUp']);
    let currAnimation = '';
    const getNeedelementent = () => {
        element = document.querySelector('.dialog-wrapper');
        dialog = element.querySelector('.dialog');
        cancelBtn = element.querySelector('.cancel-btn');
        okBtn = element.querySelector('.ok-btn');
    }

    const show = (options = {}) => {
        let {
            content = 'Please entry content',
            okText = 'ok',
            cancelText = 'cancel',
            onOk = null,
            onCancel = null,
            maskDisabled = false,
            animation = 1
        } = options;

        currAnimation = animation;
        const html = `
    <div class="dialog-wrapper fadeIn">
      <div class="dialog ${animaArr[currAnimation][0]}">
        <div class="content">${content}</div>
        <div class="buttons">
          <div class="btn ok-btn">${okText}</div>
          <div class="btn cancel-btn">${cancelText}</div>
        </div>
      </div>
    </div>
  `;
        document.body.innerHTML += html;
        getNeedelementent();
        bindEvent(onOk, onCancel, maskDisabled);
        return element;
    }

    const bindEvent = (onOk, onCancel, maskDisabled) => {
        okBtn?.addEventListener('click', e => {
            hide();
            onOk && onOk();
        })
        cancelBtn?.addEventListener('click', e => {
            hide();
            onCancel && onCancel();
        })
        if (maskDisabled) {
            element.addEventListener('click', e => {
                let target = e?.target;
                if (/dialog-wrapper/.test(target.className)) {
                    hide();
                }
            })
        }
    }

    const hide = () => {
        element.classList.add('fadeOut');
        dialog.classList.add(`${animaArr[currAnimation][1]}`);
        setTimeout(() => {
            element.remove();
        }, 200);
    }
    return {
        show,
        hide
    }
})();

window.dialog = dialog;


/*// success modal visible
function optionDialog() {
    window.dialog.show({
        content: 'Are you sure want to make payment?',
        okText: 'Yes',
        cancelText: 'Cancel',
        onOk: () => {
            const modal = document.querySelector('.js-modal')
            const modalContainer = document.querySelector('.js-modal-container')
            //Ham hien thi modal mua ve
            modal.classList.add('open')
            function showBuyTickets() {
                modal.classList.add('open')
            }
            function hideBuyTickets() {
                modal.classList.remove('open')
            }

            modalContainer.addEventListener('click', function (event) {
                event.stopPropagation()
            })
        },
        onCancel: () => { }
    })
}*/

// scrolling banner 
$(document).ready(function () {
    var offset = $('.ads').offset().top,
        top;
    $(document).on('scroll', function () {
        top = $(window).scrollTop() < offset ? '0' : $(window).scrollTop() - offset;
        console.log(top);
        $('.ads').css({
            'top': top + 210
        });
    })
});