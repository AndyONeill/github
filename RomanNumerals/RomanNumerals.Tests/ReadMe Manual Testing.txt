You can test the api using PostMan ( or your preferred tool )
Date of birth should be yyyy-MM-dd in the json

Post
https://localhost:44381/api/age

Body

{
"Name": "Peter Parker",
"DateOfBirth": "1970-12-31"
}

Choose Raw and Json

returns

{
    "createdAt": "01/05/2019 03:52:05 PM",
    "name": "Peter Parker",
    "numeral": "XLVIII"
}