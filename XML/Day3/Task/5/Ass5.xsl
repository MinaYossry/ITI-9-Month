<<<<<<< HEAD
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
				<th>Price</th>
			</tr>
			<xsl:for-each select="CD">
				<xsl:sort select="PRICE" data-type="number" order="descending"></xsl:sort>
				<tr>
					<td>
						<xsl:value-of select="TITLE"></xsl:value-of>
					</td>
					<td>
						<xsl:value-of select="ARTIST"></xsl:value-of>
					</td>
					<td>
						<xsl:value-of select="PRICE"></xsl:value-of>
					</td>
				</tr>
			</xsl:for-each>
		</tbody>
	</table>


</xsl:template>

</xsl:stylesheet>
=======
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
				<th>Price</th>
			</tr>
			<xsl:for-each select="CD">
				<xsl:sort select="PRICE" data-type="number" order="descending"></xsl:sort>
				<tr>
					<td>
						<xsl:value-of select="TITLE"></xsl:value-of>
					</td>
					<td>
						<xsl:value-of select="ARTIST"></xsl:value-of>
					</td>
					<td>
						<xsl:value-of select="PRICE"></xsl:value-of>
					</td>
				</tr>
			</xsl:for-each>
		</tbody>
	</table>


</xsl:template>

</xsl:stylesheet>
>>>>>>> 779ac28adbf2aae99359e6533901d78e981a8589
