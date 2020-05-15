# ASP.NETMVC-PDFParser
This project parse the pdf content and gets the number of pages that are having colored text and black&amp;white text

******* Points to consider ****

1. Change the paths in web.config if needed
2. Uploaded files will be saved in /Content/Uploads folder
3. Can set DeleteUploadedFile flag in web.config as true to delete the uploaded file as soon as it calculates the counts


******* Testing steps ****
1. Browse the application from visual studio
2. Click FileUploader menu 
3. Click choose file to upload a pdf 
4. After selecting the file, it asks to wait until it finishes calculating the page counts
5. Once done with calculations, it shows the count of pages having Color text, Black&White pages count & Total page count in respective textboxes
