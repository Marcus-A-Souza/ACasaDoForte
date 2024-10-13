// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.querySelector('.menuToggle').addEventListener('click', function (e) {
    e.preventDefault();
    document.querySelector('#menu').classList.toggle('active');
});

// IA da GIGI //
function startChat() {
    alert("Conectando com a Inteligência Artificial...");
    // Aqui você pode redirecionar para a IA ou iniciar o chat
    // Por exemplo, redirecionar para uma página de chat ou abrir um popup
    function handleChat() {
        var userResponse = document.getElementById('userResponse').value.trim();
        var chatQuestion = document.getElementById('chatQuestion');

        // Envia a resposta do usuário ao backend
        fetch('/Chat/GetResponseFromAI', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ message: userResponse }),
        })
            .then(response => response.json())
            .then(data => {
                chatQuestion.textContent = data.response;
            })
            .catch(error => {
                console.error('Erro:', error);
            });

        document.getElementById('userResponse').value = ''; // Limpar campo de entrada
    }

    window.location.href = "paginaChatIA.html"; // Exemplo de redirecionamento
}

