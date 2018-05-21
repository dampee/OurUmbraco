﻿namespace OurUmbraco.Emails
{
    public static class EmailsConstants
    {
        public static class EmailTemplates
        {
            public static string ActivationEmail =>
                @"<html>
                    <head>
                        <meta name='viewport' content='width=device-width'>
                        <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
                    </head>
                    
                    <body style='font-family: sans-serif; -webkit-font-smoothing: antialiased; font-size: 14px; color: #392F54; line-height: 22px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; background: #1d1333; margin: 0; padding: 0;' bgcolor='#1d1333'>
                        <style type='text/css'>
                            @media only screen and (max-width: 620px) {
                                table[class=body] h1 {
                                    font-size: 28px !important;
                                    margin-bottom: 10px !important;
                                }
                                table[class=body] .wrapper {
                                    padding: 32px !important;
                                }
                                table[class=body] .article {
                                    padding: 32px !important;
                                }
                                table[class=body] .content {
                                    padding: 24px !important;
                                }
                                table[class=body] .container {
                                    padding: 0 !important;
                                    width: 100% !important;
                                }
                                table[class=body] .main {
                                    border-left-width: 0 !important;
                                    border-radius: 0 !important;
                                    border-right-width: 0 !important;
                                }
                                table[class=body] .btn table {
                                    width: 100% !important;
                                }
                                table[class=body] .btn a {
                                    width: 100% !important;
                                }
                                table[class=body] .img-responsive {
                                    height: auto !important;
                                    max-width: 100% !important;
                                    width: auto !important;
                                }
                            }
                            
                            .btn-primary table td:hover {
                                background-color: #34495e !important;
                            }
                            
                            .btn-primary a:hover {
                                background-color: #34495e !important;
                                border-color: #34495e !important;
                            }
                            
                            .btn a:visited {
                                color: #FFFFFF;
                            }
                        </style>
                        <table border='0' cellpadding='0' cellspacing='0' class='body' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #1d1333;' bgcolor='#1d1333'>
                            <tr>
                                <td style='font-family: sans-serif; font-size: 14px; vertical-align: top; padding: 24px;' valign='top'>
                                    <table style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;'>
                                        <tr>
                                            <td background='https://our.umbraco.org/assets/images/logo.svg' bgcolor='#1d1333' width='26' height='28' valign='top' style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>
                                                <!--[if gte mso 9]> <v:rect xmlns:v='urn:schemas-microsoft-com:vml' fill='true' stroke='false' style='width:30px;height:30px;'> <v:fill type='tile' src='https://our.umbraco.org/assets/images/logo.svg' color='#1d1333' /> <v:textbox inset='0,0,0,0'> <![endif]-->
                                                <div> </div>
                                                <!--[if gte mso 9]> </v:textbox> </v:rect> <![endif]-->
                                            </td>
                                            <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table border='0' cellpadding='0' cellspacing='0' class='body' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #1d1333;' bgcolor='#1d1333'>
                            <tr>
                                <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'> </td>
                                <td class='container' style='font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; max-width: 560px; width: 560px; margin: 0 auto; padding: 10px;' valign='top'>
                                    <div class='content' style='box-sizing: border-box; display: block; max-width: 560px; margin: 0 auto; padding: 10px;'>
                                        <br>
                                        <table class='main' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; border-radius: 3px; background: #FFFFFF;' bgcolor='#FFFFFF'>
                                            <tr>
                                                <td class='wrapper' style='font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 50px;' valign='top'>
                                                    <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;'>
                                                        <tr>
                                                            <td style='line-height: 24px; font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'>
                                                                %0%
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <br>
                                        <br>
                                        <br>
                                    </div>
                                </td>
                                <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'> </td>
                            </tr>
                        </table>
                    </body>
                </html>";
        }
    }
}
