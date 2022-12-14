<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

<xsl:template match="CATALOG">
	<h2>
		My CD Collection
	</h2>
	
	<table border="2px black solid">
		<tbody>
			<tr bgcolor="lightgreen">
				<th>Title</th>
				<th>Artist</th>
			</tr>
			<xsl:for-each select="CD">
				<xsl:variable name="color">
					<xsl:choose>
						<xsl:when test="PRICE > 10">red</xsl:when>
						<xsl:otherwise>green</xsl:otherwise>
					</xsl:choose>
				</xsl:variable>
				<tr>
					<td>
						<xsl:value-of select="TITLE"></xsl:value-of>
					</td>
					<td style="background-color:{$color}">
						<xsl:value-of select="ARTIST"></xsl:value-of>
					</td>
				</tr>
			</xsl:for-each>
		</tbody>
	</table>


</xsl:template>

</xsl:stylesheet>
