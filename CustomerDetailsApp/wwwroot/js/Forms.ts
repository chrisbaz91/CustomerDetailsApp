document.addEventListener("DOMContentLoaded", () => {
    const deleteButton = document.getElementById("DeleteButton");
    if (deleteButton) {
        deleteButton.addEventListener("click", deleteButtonOnClick);
    }

    const inputs = document.getElementsByClassName("form-control");
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener("blur", () => {
            enableSubmitButton(inputs);
        });
    }

    enableSubmitButton(inputs)
});

function deleteButtonOnClick() {
    if (confirm("Are you sure you want to delete this Customer?")) {
        const id = (document.getElementById("Id") as HTMLInputElement).value;
        const indexUrl = (document.getElementById("IndexUrl") as HTMLInputElement).value;
        const deleteUrl = (document.getElementById("DeleteUrl") as HTMLInputElement).value + "/" + id;

        fetch(deleteUrl, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                if (response.ok) {
                    alert("Customer successfully deleted");
                    window.location.replace(indexUrl);
                }
                else {
                    alert("Error deleting Customer");
                }
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });
    }
}

function enableSubmitButton(inputs) {
    let disabled = "";
    const submitButton = document.getElementById("SubmitButton");

    if (submitButton) {
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].value === "") {
                disabled = "disabled";
                break;
            }
        }

        if (disabled) {
            submitButton.classList.add("disabled");
        }
        else {
            submitButton.classList.remove("disabled");
        }
    }
}