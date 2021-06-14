$(document).ready(() => {
    loadImportTable(modelReturn)
});

function detailFormatter(index, row) {
    var html = []
    html.push(`<table id="details-table-${index}" style="display: none;">
                    <thead>
                      <tr>
                        <th>Sinal</th>
                        <th>CPF</th>
                        <th>Descrição Transação</th>
                        <th>Data</th>
                        <th>Cartão</th>
                        <th>Valor</th>
                      </tr>
                    </thead>`)
    $.each(row.listTransactionDescription, function (key, value) {
        var date = new Date(value.dateTime);
        html.push(` <tr>
                        <td>${value.modelTransaction.signal}</td>
                        <td>${value.cpf}</td>
                        <td>${value.modelTransaction.description}</td>
                        <td>${date.toLocaleDateString()} ${date.toLocaleTimeString()}</td>  
                        <td>${value.card}</td>
                        <td>${value.value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</td>
                      </tr>`)
        if ((row.listTransactionDescription.length - 1) == key) {
            html.push(`</table>`)
            setTimeout(() => {
                $(`#details-table-${index}`).bootstrapTable();
                $(`#details-table-${index}`).fadeIn(500);
            }, 500)
        }
    })
    return html.join('')
}

function loadImportTable(data) {
    $('#import-table').bootstrapTable({
        data: data,
        columns: [
            [{
                field: 'storeName',
                title: 'Loja',
                align: 'center',
                formatter: function (value, row) {
                    return row.storename
                }
            }, {
                field: 'currentBalance',
                title: 'Saldo Atual',
                align: 'center',
                formatter: function (value, row) {
                    let result = `<span style="color: ${row.currentBalance < 0 ? 'red' : 'blue'}">
                                    ${row.currentBalance.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}
                                  </span>`
                    return result;
                },
            }
            ]
        ]
    });
}
function importTableHeaderStyle(column) {
    return {
        storeName: {
            css: { background: '#D3D3D3' }
        },
        currentBalance: {
            css: { background: '#D3D3D3' }
        }
    }[column.field]
}