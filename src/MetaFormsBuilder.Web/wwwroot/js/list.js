let _id = 0;
let _tipo = '';
let _url = '';

const myModal = new bootstrap.Modal(document.getElementById('deleteModal'), {
    keyboard: false
});

function del(id, name, type, url) {
    const body = `${type} ${name}`;
    document.querySelector("#modalBody-desc").textContent = body;
    _id = id;
    _type = type;
    _url = url + "/" + _id;
    myModal.show();
}

function confirmDel() {
    // XMLHttpRequest();

    let xhr = new XMLHttpRequest();
    xhr.open('delete', _url);

    xhr.onloadend = () => {
        let mensagem = { error : false, msg : ''};
        switch (xhr.status) {
            case 204:
                mensagem.error = false;
                mensagem.msg = _tipo + ' excluído';
                break;
            case 400:
                //console.log()
                mensagem.error = true;
                mensagem.msg = (_tipo == 'Categoria' ? 'existem produtos relacionados a esse categoria' : 'item não encontrado');
                break;
            case 404:
                //console.log()
                mensagem.error = true;
                mensagem.msg = _tipo + ' não existe';
            default:
                mensagem.error = true;
                mensagem.msg = 'Erro ao tentar excluir';
        }

        if (mensagem.error) {
            toastr.error(mensagem.msg, "Fansoft Store");
        } else {
            toastr.success(mensagem.msg, "Fansoft Store");
            document.getElementById('item-' + _id).remove();
            myModal.hide();
        }

    };

    xhr.send();
    
}