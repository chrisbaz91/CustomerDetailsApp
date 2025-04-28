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
    const submitButton = document.getElementById("SubmitButton");
    let value;
    let disabled = false;

    if (submitButton) {
        for (var i = 0; i < inputs.length; i++) {

            value = inputs[i].value;

            if (value === "") {
                disabled = true;
                break;
            }

            switch (inputs[i].id) {
                case "Name":
                    if (value.length > 50) {
                        disabled = true;
                    }
                    break;
                case "Age":
                    if (value < 0 || value > 110) {
                        disabled = true;
                    }
                    break;
                case "Height":
                    const heightRegex = /^[0-2](\.\d{0,2})?$/;
                    if (!heightRegex.test(value) || value < 0 || value > 2.5) {
                        disabled = true;
                    }
                    break;
                case "Postcode":
                    const postcodeRegex = /([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})/;
                    if (!postcodeRegex.test(value)) {
                        disabled = true;
                    }
                    break;

            }

            if (disabled) {
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