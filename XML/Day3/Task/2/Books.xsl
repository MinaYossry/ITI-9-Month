<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

<xsl:template match="books">
<h1>
	A list of books
</h1>
<table border="1px black solid">
	<tbody>
		<xsl:for-each select="book">
			<tr>
				<td width="20px">
					<xsl:value-of select="position()"></xsl:value-of>
				</td>
				<td width="200px">
					<xsl:value-of select="author"></xsl:value-of>
				</td>
				<td width="200px">
					<xsl:value-of select="title"></xsl:value-of>
				</td>
				<td width="70px">
					<xsl:value-of select="price"></xsl:value-of>
				</td>
			</tr>
		</xsl:for-each>
	</tbody>
</table>

</xsl:template>

</xsl:stylesheet>
