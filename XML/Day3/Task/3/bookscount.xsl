<<<<<<< HEAD
<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

<xsl:template match="books">

<xsl:text>Review of 3.5: </xsl:text>
<xsl:value-of select="count(book[review = 3.5])"></xsl:value-of>
<xsl:element name="br"></xsl:element>
<xsl:element name="br"></xsl:element>

<xsl:text>Review of 4: </xsl:text>
<xsl:value-of select="count(book[review = 4])"></xsl:value-of>

</xsl:template>

</xsl:stylesheet>
=======
<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

<xsl:template match="books">

<xsl:text>Review of 3.5: </xsl:text>
<xsl:value-of select="count(book[review = 3.5])"></xsl:value-of>
<xsl:element name="br"></xsl:element>
<xsl:element name="br"></xsl:element>

<xsl:text>Review of 4: </xsl:text>
<xsl:value-of select="count(book[review = 4])"></xsl:value-of>

</xsl:template>

</xsl:stylesheet>
>>>>>>> 779ac28adbf2aae99359e6533901d78e981a8589
