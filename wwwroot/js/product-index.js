// Product Index page scripts
// Filtering, cart, and toastr notification logic

$(document).ready(function() {
    // Lọc sản phẩm theo danh mục
    $(document).on('click', '#categoryPills .nav-link', function() {
        $('#categoryPills .nav-link').removeClass('active');
        $(this).addClass('active');
        filterProducts();
    });
    // Lọc sản phẩm theo giá
    $('#priceFilter').on('change', function() {
        filterProducts();
    });
    // Tìm kiếm sản phẩm
    $('#search').on('input', function() {
        filterProducts();
    });
    function filterProducts() {
        var category = $('#categoryPills .nav-link.active').data('category');
        var price = $('#priceFilter').val();
        var search = $('#search').val().toLowerCase();
        $('#productListRow .product-item').each(function() {
            var show = true;
            var itemCat = $(this).data('category');
            var itemPrice = parseFloat($(this).data('price'));
            var itemName = $(this).data('name');
            // Sửa lỗi lọc: so sánh ép kiểu về chuỗi để luôn đúng
            if (typeof category !== 'undefined' && category !== "" && String(itemCat) !== String(category)) show = false;
            if (price === 'low' && itemPrice >= 100000) show = false;
            if (price === 'medium' && (itemPrice < 100000 || itemPrice > 200000)) show = false;
            if (price === 'high' && itemPrice <= 200000) show = false;
            if (search && !itemName.includes(search)) show = false;
            $(this).closest('.col').toggle(show);
        });
    }
    // Giỏ hàng đơn giản
    let cart = JSON.parse(localStorage.getItem('cart') || '[]');
    window.addToCart = function(id, name) {
        let found = cart.find(x => x.id == id);
        if (found) found.qty++;
        else cart.push({ id, name, qty: 1 });
        localStorage.setItem('cart', JSON.stringify(cart));
        renderCart();
        toastr.success('Đã thêm ' + name + ' vào giỏ hàng!');
    }
    function renderCart() {
        let html = '';
        if (cart.length === 0) {
            html = `<li class="list-group-item text-center py-4 text-muted">
                <i class="fas fa-shopping-cart fa-2x mb-2"></i><br>Chưa có sản phẩm nào
            </li>`;
        } else {
            html = cart.map(x => `
                <li class="list-group-item d-flex justify-content-between align-items-center py-3">
                    <div class="d-flex align-items-center gap-2">
                        <i class="fas fa-utensils text-warning"></i>
                        <span class="fw-semibold">${x.name}</span>
                    </div>
                    <div class="d-flex align-items-center gap-2">
                        <button class="btn btn-sm btn-outline-secondary" onclick="changeQty('${x.id}',-1)">-</button>
                        <span class="badge bg-light text-dark border px-2">${x.qty}</span>
                        <button class="btn btn-sm btn-outline-secondary" onclick="changeQty('${x.id}',1)">+</button>
                        <button class="btn btn-sm btn-outline-danger ms-2" onclick="removeFromCart('${x.id}')"><i class="fas fa-trash"></i></button>
                    </div>
                </li>
            `).join('');
        }
        $('#cartList').html(html);
    }
    window.changeQty = function(id, delta) {
        let found = cart.find(x => x.id == id);
        if (found) {
            found.qty += delta;
            if (found.qty <= 0) cart = cart.filter(x => x.id != id);
            localStorage.setItem('cart', JSON.stringify(cart));
            renderCart();
        }
    }
    window.removeFromCart = function(id) {
        cart = cart.filter(x => x.id != id);
        localStorage.setItem('cart', JSON.stringify(cart));
        renderCart();
    }
    $('#checkoutBtn').on('click', function() {
        if (cart.length === 0) {
            toastr.warning('Giỏ hàng trống!');
            return;
        }
        toastr.success('Cảm ơn bạn đã đặt hàng! (Demo)');
        cart = [];
        localStorage.setItem('cart', JSON.stringify(cart));
        renderCart();
    });
    renderCart();
});

$(function() {
    renderCart();
    updateCartSummary();
    // Đảm bảo addToCart là global để nút onclick gọi được
    window.addToCart = function(id, name) {
        let found = cart.find(x => x.id == id);
        if (found) found.qty++;
        else cart.push({ id, name, qty: 1 });
        localStorage.setItem('cart', JSON.stringify(cart));
        renderCart();
        updateCartSummary && updateCartSummary();
        toastr.success('Đã thêm ' + name + ' vào giỏ hàng!');
    }
});
